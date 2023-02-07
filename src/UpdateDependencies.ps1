cls
$latest = Invoke-WebRequest "https://api.github.com/repos/samsmithnz/PuzzleSolver/releases/latest"
$tagName = ($latest.Content | ConvertFrom-Json).tag_name
Write-Host "Downloading files for release $tagName"

Invoke-WebRequest -UseBasicParsing -Uri "https://github.com/samsmithnz/PuzzleSolver/releases/download/$tagName/PuzzleSolver.deps.json" -OutFile c:\users\samsm\downloads\PuzzleSolver.deps.json
Invoke-WebRequest -UseBasicParsing -Uri "https://github.com/samsmithnz/PuzzleSolver/releases/download/$tagName/PuzzleSolver.pdb" -OutFile c:\users\samsm\downloads\PuzzleSolver.pdb
Invoke-WebRequest -UseBasicParsing -Uri "https://github.com/samsmithnz/PuzzleSolver/releases/download/$tagName/PuzzleSolver.dll" -OutFile c:\users\samsm\downloads\PuzzleSolver.dll


Unblock-File -Path c:\users\samsm\downloads\PuzzleSolver.dll
Unblock-File -Path c:\users\samsm\downloads\PuzzleSolver.pdb
Unblock-File -Path c:\users\samsm\downloads\PuzzleSolver.deps.json

Move-Item -Path c:\users\samsm\downloads\PuzzleSolver.dll -Destination C:\Users\samsm\source\repos\PuzzleSolver\src\Puzzle3dSimulation\Assets\PuzzleSolverDependencies -Force
Move-Item -Path c:\users\samsm\downloads\PuzzleSolver.pdb -Destination C:\Users\samsm\source\repos\PuzzleSolver\src\Puzzle3dSimulation\Assets\PuzzleSolverDependencies -Force
Move-Item -Path c:\users\samsm\downloads\PuzzleSolver.deps.json -Destination C:\Users\samsm\source\repos\PuzzleSolver\src\Puzzle3dSimulation\Assets\PuzzleSolverDependencies -Force

pause