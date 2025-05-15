using Commen.Enums;
using DAL.Entity;
using Microsoft.EntityFrameworkCore;

namespace DAL.DataBase;

public static class SeedData
{
     public static void DataSeed(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Users>().HasData(
          new { Id = 1, Email = "shashanksh72@yopmail.com", Password = "shashank@123", IsManager = true },
          new { Id = 2, Email = "shashank.step2gen@yopmail.com", Password = "shank@123", IsManager = false },
          new { Id = 3, Email = "raju@yopmail.com", Password = "raju@123", IsManager = false },
          new { Id = 4, Email = "step2gen@yopmail.com", Password = "step2gen@1234", IsManager = true },
          new { Id = 5, Email = "yuta@yopmail.com", Password = "yuta@123", IsManager = false }
          );
    }

    public static void DataSeedAccount(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Accounts>().HasData(
            new { Id =1 , UserId = 2 , AccountNumber = "AD00000034" , Pin = "3456" , Name = "Shashank" , PhoneNumber = "87968756483" , AccountType = AccountTypeEnum.Saving , Balance = 4562.00m},
            new { Id =2 , UserId = 3 , AccountNumber = "AD00000044" , Pin = "3456" , Name = "Step2gen" , PhoneNumber = "87968756483" , AccountType = AccountTypeEnum.Current , Balance = 5000.00m},
            new { Id =3 , UserId = 4 , AccountNumber = "AD00000056" , Pin = "3456" , Name = "raju" , PhoneNumber = "87968756483" , AccountType = AccountTypeEnum.Saving , Balance = 6000.00m},
            new { Id =4 , UserId = 5 , AccountNumber = "AD00000067" , Pin = "3456" , Name = "Yuta" , PhoneNumber = "87968756483" , AccountType = AccountTypeEnum.Current , Balance = 7000.00m}
            );
    }
    public static void DataSeedCash(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ATMCashInventory>().HasData(
            new { Id =1 , Denomination = 100 , Count =0},
            new { Id =2 , Denomination = 200 , Count =0},
            new { Id =3 , Denomination = 500 , Count =0},
            new { Id =4 , Denomination = 2000 , Count =0}
            );
    }
}
