#include <iostream>
#include <string>
#include <sstream>


#define HashCalculator _declspec(dllexport)

extern "C" {
	HashCalculator void CalculateAtmHash(const char* startChar, const int length, char* hashChar, int& hashLength) {
        // Build the hex string by converting chars to hex
        
        std::stringstream stream;
        for (int i = 0; i < length; ++i) {
            stream << std::hex << (int)startChar[i];
        }
        std::string hexString = stream.str();

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