# ATMMeasurements
Project Overview

The goal of this exercise is to create an application that allows a user to manage basic ATM
measurements for several ATMs as well as calculating and displaying a hash value for the ATM. The
application will need to be able to create new ATMs, read existing ATMs, update parameters for the
ATMs, and delete an ATM.
Each ATM should have the following data fields and limits. All fields should be visible and editable from
the UI


• ATM ID – A unique identifier

• Description – Free form text

• ATM Length – No limit

• ATM Width – Max of 800

• ATM Height – Min of 100

The ATM hash value should be calculated using a C++ DLL and then displayed in the UI. Details of the
hash calculation method are outlined in detail in the below architecture section.

Expected Architecture

At a high level, the code is organized into the layers outlined below. The detailed requirements of each layer and
specific parameters are highlighted.

UI Layer

The UI layer should use the Blazor UI. This layer should demonstrate use of View/ViewModel separation
and UI databinding usage

Service API Layer

Exposes an API via IIS or self hosted for consumption by the UI layer.

Business Layer

This layer should contain all of the business logic required to create, read, update, and delete ATM
parameters.

• ATM height min = 100

• ATM width max = 800

In addition to the create, read, update, and delete methods the business layer should also provide a
method to calculate the hash for an ATM. Use the following parameters and structure to calculate the
hash.

• Set the ATM Description string into a byte array

• Call the C++ DLL library CalculateAtmHash method passing:

o the first byte of the Atm Description byte array as [In] parameter one

o the number of bytes in Atm Description byte array as [In] parameter two

o the first byte of a 100 byte array as [Out] parameter three

o zero as [Out] parameter four

• Return to the caller a .net string formed from the [Out] parameter three for the length of bytes

specified in [Out] parameter four

Data Access Layer

This is used to interact with the datastore and is the only layer that will have direct access to the
datastore.

C++ DLL library

This library is unmanaged (not .NET runtime) and exposes a method to calculate the ATM hash.
The method has two [in] parameters and two [out] parameters as outlined below.

• [In, ref] Parameter one is of type char (not char array, a single char)

• [In, value] Parameter two is of type int

• [Out, ref] Parameter three is of type char (not char array, a single char)

• [Out, value] Parameter four is of type int

The hash calculation logic is:

• Each char starting at the char specified in parameter one for the length specified in
parameter two is converted to a hex string and concatenated to form a single string

o For example “446965626F6C642041746D206F6E2073616C657320666C6F6F72"

• Sum the ASCII value of each char of the resulting hex string

• Convert the sum numeric value to a char array whose first char is that of [Out]
parameter three

• Set the number of bytes represented in [Out] parameter three as the [Out] parameter
four int

SQL Server Datastore

The datastore is architected using the following guidelines:

• Use a single table or more (ATM)

• Two or more fields in each table (ID, Description, Length, Width, Height)

• No use of triggers

• No use of database functions

• No use of stored procedures

A backup of the Database is included in the root of the repo.

