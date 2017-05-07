#wait for sql server to start
sleep 20s

/opt/mssql-tools/bin/sqlcmd -S localhost -U sa -d master -i setup.sql -P $SA_PASSWORD

/opt/mssql-tools/bin/bcp CodePersuit.dbo.[User] in '/usr/src/app/User.csv' -c -t',' -S localhost -U sa -P $SA_PASSWORD
/opt/mssql-tools/bin/bcp CodePersuit.dbo.[Repository] in '/usr/src/app/Repository.csv' -c -t',' -S localhost -U sa -P $SA_PASSWORD