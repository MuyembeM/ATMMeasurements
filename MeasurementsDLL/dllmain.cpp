// dllmain.cpp : Defines the entry point for the DLL application.
#include "pch.h"
/*#include <iostream>
#include <string>
#include <sstream>*/

// Helper function to convert a char to hex string
/*std::string CharToHexString(char c) {
    std::stringstream stream;
    stream << std::hex << (int)c;
    return stream.str();
}

// Calculate the ATM hash
void CalculateATMHash(const char& startChar, const int length, char& hashChar, int hashLength) {
    // Build the hex string by converting chars to hex
    std::string hexString;
    for (int i = 0; i < length; ++i) {
        hexString += CharToHexString(startChar + i);
    }

    // Sum the ASCII values of each char in the hex string
    int sum = 0;
    for (char c : hexString) {
        sum += static_cast<int>(c);
    }

    // Convert the sum to a char
    hashChar = static_cast<char>(sum);

    // Set the hash length
    hashLength = static_cast<int>(hexString.length());
}*/


extern "C" BOOL APIENTRY DllMain(HMODULE hModule, DWORD ul_reason_for_call, LPVOID lpReserved)
{
    switch (ul_reason_for_call)
    {
        case DLL_PROCESS_ATTACH:
        case DLL_THREAD_ATTACH:
        case DLL_THREAD_DETACH:
        case DLL_PROCESS_DETACH:
            break;
    }
    return TRUE;
}

// Initialization function to be called from managed code
/*extern "C" __declspec(dllexport) bool InitializeDLL(char& startChar, int length, char& hashChar, int hashLength)
{
    CalculateATMHash(startChar, length, hashChar, hashLength);
    return true;
}*/

extern "C" __declspec(dllexport) bool InitializeDLL()
{
    // Display a message box
    MessageBox(NULL, L"Hello, World!", L"Message Box Example", MB_ICONINFORMATION | MB_OK);
    return true;
}




