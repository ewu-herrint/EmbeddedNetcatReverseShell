# EmbeddedNetcatReverseShell
Playing around with embedding netcat into a program and having it send a reverse shell request when ran.

A pretty simple proof of concept of embedding a netcat.exe into a C# program I made that rolls dice.
Upon running the dice roller the program creates a VBScript, a batch file, and extracts netcat (named dice2.exe)
into your temp folder and runs the VBScript that hides and launches the batch file that runs netcat with commands
that start a reverse shell if someone is listening on the specified port and IP.

I take no responsibility if anyone uses this program maliciously.
