DB Oluştuktan sonra Package Manager Console’dan aşağıdaki migration’ların çalıştırılması gerekmektedir:

Update-Database -StartupProject Presentation -Project Infrastructure -Context UserDbContext
Update-Database -StartupProject Presentation -Project Infrastructure -Context InstructionDbContext
Update-Database -StartupProject Presentation -Project Infrastructure -Context NotificationDbContext
