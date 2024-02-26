Set-Location "C:\Inetpub\wwwroot\PACRAT"
Start-Process -WindowStyle Maximized "C:\Inetpub\wwwroot\PACRAT"
Start-Process -WindowStyle Maximized PACRAT.sln
IF (Test-Path "C:\Program Files\MySQL\MySQL Workbench\MySQLWorkbench.exe")
  {
  Start-Process -WindowStyle Maximized "C:\Program Files\MySQL\MySQL Workbench\MySQLWorkbench.exe"
  }
ELSE
  {
  Start-Process -WindowStyle Maximized "C:\Program Files (x86)\MySQL\MySQL Workbench\MySQLWorkbench.exe"
  }
