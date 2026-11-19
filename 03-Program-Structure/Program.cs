// ============================================================
// Lesson 03: Structure of a C# Program
// CSharp Learning Journey
// ============================================================
//
// In this lesson, we learn the basic structure of a C# program.
//
// Topics:
// 1. Console Output
// 2. Using Directives
// 3. Namespace
// 4. Classes
// 5. Main Method
// 6. Statements and Code Blocks
// 7. Comments
// 8. Case Sensitivity
//
// ============================================================

using System;

namespace MyFirstProject
{
    class Program
    {
        static void Main(string[] args)
        {
            // =================================================
            // 01 - CONSOLE OUTPUT
            // =================================================
            //
            // Console.WriteLine() prints text to the console
            // and moves the cursor to the next line.

            Console.WriteLine("CSharp Learning Journey - Lesson 03");
            Console.WriteLine("Structure of a C# Program");


            // =================================================
            // 02 - BASIC OUTPUT
            // =================================================
            //
            // We can use Console.WriteLine() to display
            // messages and information.

            Console.WriteLine("Hello World!");


            // =================================================
            // 03 - CONSOLE.WRITE VS CONSOLE.WRITELINE
            // =================================================
            //
            // Console.Write() prints without moving to a new line.
            //
            // Console.WriteLine() prints and moves to a new line.

            /*
            Console.Write("Hello ");
            Console.Write("Kiyan ");

            Console.WriteLine("Welcome to C#!");
            Console.WriteLine("Let's start coding.");
            */


            // =================================================
            // 04 - CODE BLOCKS
            // =================================================
            //
            // Curly braces { } define a code block.
            //
            // Code blocks are used to organize statements
            // inside classes, methods, loops, and conditions.

            /*
            if (true)
            {
                Console.WriteLine("This code block is executed.");
            }
            */


            // =================================================
            // 05 - COMMENTS
            // =================================================
            //
            // Single-line comment:
            // Used to explain a single line of code.

            // This is a single-line comment.


            // Multi-line comment:
            // Used for longer explanations.

            /*
            This is a multi-line comment.
            We can write multiple lines here.
            */


            // XML Documentation Comment:
            // Used to document classes, methods, and other members.

            /// <summary>
            /// This is an example of XML documentation.
            /// </summary>


            // =================================================
            // 06 - CASE SENSITIVITY
            // =================================================
            //
            // C# is case-sensitive.
            //
            // Main is different from main.
            // Console is different from console.
            // age is different from Age.

            /*
            int age = 18;

            int Age = 20;

            Console.WriteLine(age);
            Console.WriteLine(Age);
            */


            // =================================================
            // 07 - BASIC IF STATEMENT
            // =================================================
            //
            // An if statement executes its code block
            // when its condition is true.

            /*
            if (true)
            {
                Console.WriteLine("The condition is true.");
            }
            */


            // =================================================
            // LESSON 03 SUMMARY
            // =================================================
            //
            // - using
            // - namespace
            // - class
            // - Main method
            // - Console.WriteLine()
            // - Console.Write()
            // - Statements
            // - Code blocks
            // - Comments
            // - Case sensitivity
            //
            // A C# program is organized using different structures
            // that help us write readable, organized,
            // and maintainable code.
            //
            // =================================================
        }
    }
}