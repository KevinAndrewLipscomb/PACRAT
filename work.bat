REM
REM $Id: work.bat 5487 2014-11-22 22:50:44Z kevinanlipscomb $
REM
cd "C:\Inetpub\wwwroot\PACRAT"
start /max explorer /e,/select,C:\Inetpub\wwwroot\PACRAT\.svn
start /max PACRAT.sln
IF EXIST "C:\Program Files\MySQL\MySQL Workbench\MySQLWorkbench.exe" (start "" /max "C:\Program Files\MySQL\MySQL Workbench\MySQLWorkbench.exe") ELSE start "" /max "C:\Program Files (x86)\MySQL\MySQL Workbench\MySQLWorkbench.exe"
