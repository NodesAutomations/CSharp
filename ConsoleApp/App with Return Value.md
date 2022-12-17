Main() Return Values (C# Programming Guide)
Article
02/15/2013
2 minutes to read
The Main method can return void:

C#

Copy
static void Main()
{
    //...
}
It can also return an int:

C#

Copy
static int Main()
{
    //... 
    return 0;
}
If the return value from Main is not used, returning void allows for slightly simpler code. However, returning an integer enables the program to communicate status information to other programs or scripts that invoke the executable file. The following example shows how the return value from Main can be accessed.

Example
In this example, a batch file is used to run a program and test the return value of the Main function. When a program is executed in Windows, any value returned from the Main function is stored in an environment variable called ERRORLEVEL. A batch file can determine the outcome of execution by inspecting the ERRORLEVEL variable. Traditionally, a return value of zero indicates successful execution. The following example is a simple program that returns zero from the Main function. The zero indicates that the program ran successfully. Save the program as MainReturnValTest.cs.

C#

Copy
class MainReturnValTest
{
    static int Main()
    {
        //... 
        return 0;
    }
}
Because this example uses a batch file, it is best to compile the code from a command prompt. Follow the instructions in How to: Set Environment Variables to enable command-line builds, or use the Visual Studio Command Prompt, available from the Start menu under Visual Studio Tools. From the command prompt, navigate to the folder in which you saved the program. The following command compiles MainReturnValTest.cs and produces the executable file MainReturnValTest.exe.

csc MainReturnValTest.cs

Next, create a batch file to run MainReturnValTest.exe and to display the result. Paste the following code into a text file and save it as test.bat in the folder that contains MainReturnValTest.cs and MainReturnValTest.exe. Run the batch file by typing test at the command prompt.

Because the code returns zero, the batch file will report success. However, if you change MainReturnValTest.cs to return a non-zero value and then re-compile the program, subsequent execution of the batch file will report failure.


Copy
rem test.bat
@echo off
MainReturnValueTest
@if "%ERRORLEVEL%" == "0" goto good

:fail
    echo Execution Failed
    echo return value = %ERRORLEVEL%
    goto end

:good
    echo Execution succeeded
    echo Return value = %ERRORLEVEL%
    goto end

:end
Sample Output
Execution succeeded

Return value = 0
