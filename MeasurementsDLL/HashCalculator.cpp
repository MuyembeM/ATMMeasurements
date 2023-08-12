#include <iostream>
#include <string>
#include <sstream>


// Helper function to convert a char to hex string
std::string CharToHexString(char c) {
    std::stringstream stream;
    stream << std::hex << (int)c;
    return stream.str();
}


#define HashCalculator _declspec(dllexport)

extern "C" {
	HashCalculator void CalculateAtmHash(const char* startChar, const int length, char* hashChar, int& hashLength) {
        // Build the hex string by converting chars to hex
        std::string hexString;
        for (int i = 0; i < length; ++i) {
            hexString += CharToHexString(startChar[i]);
        }

        // Sum the ASCII values of each char in the hex string
        int sum = 0;
        for (char c : hexString) {
            sum += static_cast<int>(c);
        }

        // Convert the sum to a char
        std::string sumStr = std::to_string(sum);

        // Copy characters from the string to the char array
        for (int i = 0; i < sumStr.length(); ++i) {
            hashChar[i] = sumStr[i];
        }

        // Set the hash length
        hashLength = sumStr.length();
        
	}
}