Invoke-WebRequest -UseBasicParsing -Uri https://github.com/samsmithnz/puzzlesolver/releases/latest/download/PuzzleSolver.Logic.deps.json -OutFile c:\users\samsm\downloads\PuzzleSolver.Logic.deps.json
Invoke-WebRequest -UseBasicParsing -Uri https://github.com/samsmithnz/puzzlesolver/releases/latest/download/PuzzleSolver.Logic.pdb -OutFile c:\users\samsm\downloads\PuzzleSolver.Logic.pdb
Invoke-WebRequest -UseBasicParsing -Uri https://github.com/samsmithnz/puzzlesolver/releases/latest/download/PuzzleSolver.Logic.dll -OutFile c:\users\samsm\downloads\PuzzleSolver.Logic.dll

Unblock-File -Path c:\users\samsm\downloads\PuzzleSolver.Logic.deps.json
Unblock-File -Path c:\users\samsm\downloads\PuzzleSolver.Logic.pdb
Unblock-File -Path c:\users\samsm\downloads\PuzzleSolver.Logic.dll

Move-Item -Path c:\users\samsm\downloads\PuzzleSolver.Logic.deps.json -Destination C:\Users\samsm\source\repos\TBS\TBS\Assets\PuzzleSolverDependencies -Force
Move-Item -Path c:\users\samsm\downloads\PuzzleSolver.Logic.pdb -Destination C:\Users\samsm\source\repos\TBS\TBS\Assets\PuzzleSolverDependencies -Force
Move-Item -Path c:\users\samsm\downloads\PuzzleSolver.Logic.dll -Destination C:\Users\samsm\source\repos\TBS\TBS\Assets\PuzzleSolverDependencies -Force

pause