// generated by tools
// AHeadLib.Net
// https://github.com/bodong1987/AHeadLib.Net
// Powered by bodong

#include "MemoryPatchConfig.h"
#include <cassert>
#include <string>
#include "MiniTools.h"

namespace
{
template <typename TCharType>
inline bool CanTrim(TCharType ch)
{
    return ch == ' ' || ch == '\t' || ch == '\n' || ch == '\r';
}

inline int CompareN(const char* first, const char* second, std::size_t n)
{
    return strncmp(first, second, n);
}

inline bool StartWith(const std::string& str, const std::string& start)
{
    return str.size() >= start.size() && CompareN(str.c_str(), start.c_str(), start.size()) == 0;
}

template<typename Predicate>
inline std::string& TrimLeft(std::string& str, Predicate predicate)
{
    for (SIZE_T i = 0; i < str.size(); ++i)
    {
        if (!predicate(str[i]))
        {
            if (i > 0)
            {
                str.erase(0, i);
            }

            break;
        }
    }

    return str;
}

inline std::string& TrimLeft(std::string& str)
{
    return TrimLeft(str, CanTrim<char>);
}

template<typename Predicate>
inline std::string& TrimRight(std::string& str, Predicate predicate)
{
    if (str.empty())
    {
        return str;
    }

    for (auto i = str.size() - 1; i != std::string::npos && i < str.size(); --i)
    {
        if (!predicate(str[i]))
        {
            if (i < str.size() - 1)
            {
                str.erase(i + 1, str.size() - i - 1);
            }

            break;
        }
    }

    return str;
}

inline std::string& TrimRight(std::string& str)
{
    return TrimRight(str, CanTrim<char>);
}

inline std::string& Trim(std::string& str)
{
    TrimLeft(str);
    TrimRight(str);
    return str;
}

inline std::string TrimCopy(const std::string& str)
{
    auto result = str;
    Trim(result);
    return result;
}

template <typename Predicate>
inline std::string::size_type Find(const std::string& str, Predicate predicate, std::string::size_type startPos = 0)
{
    for (auto i = startPos; i < str.size(); ++i)
    {
        if (predicate(str[i]))
        {
            return i;
        }
    }

    return std::string::npos;
}

template <typename TSequenceType, typename Predicate>
inline TSequenceType& Split(TSequenceType& sequence, const std::string& str, Predicate predicate)
{
    typedef std::string::size_type SizeType;

    SizeType startPos = 0;
    SizeType pos = std::string::npos;
    while ((pos = Find<Predicate>(str, predicate, startPos)) != std::string::npos)
    {
        if (pos == startPos)
        {
            startPos = pos + 1;
            continue;
        }

        std::string token = str.substr(startPos, pos - startPos);
        sequence.emplace_back(std::move(token));
        startPos = pos + 1;
    }

    if (startPos < str.size())
    {
        sequence.emplace_back(str.substr(startPos));
    }

    return sequence;
}    
}

MemoryPatchConfigParser::MemoryPatchConfigParser(const char* text)
{
    assert(text != nullptr);

    std::vector<std::string> lines;
    Split(lines, text, [](char ch)
        {
            return ch == '\n';
        });

    MemoryPatchConfig config;
        
    for (auto& str : lines)
    {
        Trim(str);

        if (StartWith(str, ";"))
        {
            continue;
        }
        else if (StartWith(str, "library"))
        {
            config.ModuleName = GetName(str);

            if (config.ModuleName == "0")
            {
                config.ModuleName.clear();
            }
        }
        else if (StartWith(str, "segment"))
        {
            config.SegmentName = GetName(str);
        }
        else if (StartWith(str, "signature"))
        {
            config.Signature = GetBytes(str);
        }
        else if (StartWith(str, "newBytes"))
        {
            config.NewBytes = GetBytes(str);
        }

        if (config.IsValid())
        {
            Configurations.emplace_back(std::move(config));

            config = MemoryPatchConfig();
        }
    }

    if (config.IsValid())
    {
        Configurations.emplace_back(std::move(config));
        config = MemoryPatchConfig();
    }
}

std::string MemoryPatchConfigParser::GetName(const std::string& text)
{
    const auto pos = text.find_first_of(':', 0);

    return pos == std::string::npos ? std::string() : TrimCopy(text.substr(pos + 1));
}

BYTE ConvertHexStringToByte(const std::string& str)
{
    if (str.size() > 2 && str[0] == '0' && toupper(str[1]) == 'X')
    {
        return static_cast<BYTE>(strtoul(str.c_str() + 2, nullptr, 16));
    }

    return static_cast<BYTE>(strtoul(str.c_str(), nullptr, 16));
}

std::vector<BYTE> MemoryPatchConfigParser::GetBytes(const std::string& text)
{
    const auto pos = text.find_first_of(':', 0);

    if (pos == std::string::npos)
    {
        return {};
    }

    const std::string values = TrimCopy(text.substr(pos + 1));

    std::vector<std::string> hexValues;
    Split(hexValues, values, [](char ch) { return ch == ' '; });

    std::vector<BYTE> bytes;

    for (auto& hexText : hexValues)
    {
        BYTE v = ConvertHexStringToByte(TrimCopy(hexText));

        bytes.push_back(v);
    }

    return bytes;
}

void PatchMemoryWithConfig(const std::vector<MemoryPatchConfig>& configs)
{
    for (auto& config : configs)
    {
        if (config.IsValid())
        {
            const HMODULE module = GetModuleHandleA(config.ModuleName.empty() ? nullptr : config.ModuleName.c_str());

            PatchMemory(module, config.SegmentName.c_str(), config.Signature.data(), config.NewBytes.data(), static_cast<int>(config.NewBytes.size()));
        }
    }
}

std::string LoadTextResource(int resourceId)
{
    HMODULE hModule = nullptr;
    GetModuleHandleEx(
        GET_MODULE_HANDLE_EX_FLAG_FROM_ADDRESS,
        reinterpret_cast<LPCTSTR>(LoadTextResource),
        &hModule);

    const HRSRC hResource = FindResource(hModule, MAKEINTRESOURCE(resourceId), TEXT("TXT"));
    if (hResource == nullptr)
    {
        return "";
    }


    const HGLOBAL hMemory = LoadResource(hModule, hResource);
    if (hMemory == nullptr)
    {
        return "";
    }

    const DWORD dwSize = SizeofResource(hModule, hResource);
    const auto lpAddress = LockResource(hMemory);

    // ReSharper disable once CppReinterpretCastFromVoidPtr
    return std::string(reinterpret_cast<char*>(lpAddress), dwSize);  // NOLINT(modernize-return-braced-init-list)
}

std::vector<MemoryPatchConfig> LoadConfigurations(int resourceId)
{
    const std::string str = LoadTextResource(resourceId);

    MemoryPatchConfigParser parser(str.c_str());

    return parser.TakeConfigurations();
}

std::string LoadFileConfigText()
{
    HMODULE hModule = nullptr;
    GetModuleHandleEx(
        GET_MODULE_HANDLE_EX_FLAG_FROM_ADDRESS,
        reinterpret_cast<LPCTSTR>(LoadFileConfigText),
        &hModule);

    TCHAR ModulePath[MAX_PATH];
    GetModuleFileName(hModule, ModulePath, MAX_PATH);

    std::basic_string<TCHAR> strPath = ModulePath;

    const size_t pos = strPath.find_last_of(TEXT("."));
    if (pos != std::string::npos)
    {
        strPath = strPath.substr(0, pos);
    }

    strPath += TEXT(".patchconfig");

    return LoadFileContent(strPath.c_str());
}

std::string LoadFileContent(const TCHAR* path)
{
    const HANDLE hFile = CreateFile(path, GENERIC_READ, 0, nullptr, OPEN_EXISTING, FILE_ATTRIBUTE_NORMAL, nullptr);
    if (hFile == INVALID_HANDLE_VALUE)
    {
        return "";
    }


    const DWORD fileSize = GetFileSize(hFile, nullptr);
    if (fileSize == INVALID_FILE_SIZE)
    {
        CloseHandle(hFile);
        return "";
    }

    const auto buffer = new char[fileSize + 1];
    DWORD bytesRead;
    if (!ReadFile(hFile, buffer, fileSize, &bytesRead, nullptr) || bytesRead != fileSize)
    {
        delete[] buffer;
        CloseHandle(hFile);
        return "";
    }

    buffer[bytesRead] = '\0'; // Add null terminator

    std::string content = buffer;
    delete[] buffer;
    CloseHandle(hFile);

    return content;
}

std::vector<MemoryPatchConfig> LoadFileConfigurations()
{
    const auto str = LoadFileConfigText();

    MemoryPatchConfigParser parser(str.c_str());

    return parser.TakeConfigurations();
}

