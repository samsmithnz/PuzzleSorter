
cls
# Download latest release from GitHub
#$credentials="myPersonalAccessToken"
#$headers = New-Object "System.Collections.Generic.Dictionary[[String],[String]]"
#$headers.Add("Authorization", "token $credentials")
$repo = "samsmithnz/puzzlesolver"
$releases = "https://api.github.com/repos/$repo/releases"


Write-Host Determining latest release
#$tag = (Invoke-WebRequest $releases -Headers $headers | ConvertFrom-Json)[0].tag_name
$tag = (Invoke-WebRequest $releases | ConvertFrom-Json)[0].tag_name
$file = "$tag.zip"

$details = Invoke-WebRequest "https://api.github.com/repos/$repo/releases/tags/$tag"
$zip = "C:\users\samsm\downloads\$file"

#https://github.com/samsmithnz/PuzzleSolver/archive/refs/tags/0.3.4.zip
$download = "https://github.com/$repo/archive/refs/tags/$file"
$name = $file.Split(".")[0]
$dir = "$name-$tag"


Write-Host Downloading latest release
Invoke-WebRequest $download -Out $zip

Write-Host Unblocking download
Unblock-File -Path $zip

Write-Host Extracting release files
$unzipPath = ($zip).Replace("$file","").Replace('downloads\','downloads') + "\$tag"
Expand-Archive $zip -Force -DestinationPath $unzipPath




pause