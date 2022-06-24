# NUnit Installation

1. Download Nunit from https://github.com/nunit/nunitv2/releases/tag/2.6.4.
2. Install.
3. Add the environment variable with path `C:\Program Files (x86)\NUnit 2.6.4\bin`.
4. Open the command prompt and chnage directory to the project bin folder.
5. Run the below command

	`nunit-console.exe /xml:results.xml path/to/test/assembly.dll`