using System;
using System.Collections.Generic;
using System.Xml;
using Microsoft.EntityFrameworkCore;

namespace Kroells_Bank_API2.Models;

public partial class KroellsBankContext : DbContext
{
    public KroellsBankContext()
    {
    }

    public KroellsBankContext(DbContextOptions<KroellsBankContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Account> Accounts { get; set; }

    public virtual DbSet<Address> Addresses { get; set; }

    public virtual DbSet<Card> Cards { get; set; }

    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<ClientAccount> ClientAccounts { get; set; }

    public virtual DbSet<ClientJob> ClientJobs { get; set; }

    public virtual DbSet<Cpr> Cprs { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Job> Jobs { get; set; }

    public virtual DbSet<Loan> Loans { get; set; }

    public virtual DbSet<Transaction> Transactions { get; set; }

    public virtual DbSet<ClientInformation> ClientInformation { get; set; }

    public virtual DbSet<CardInfo> CardInfo { get; set; }

    public virtual DbSet<LoginReturn> LoginReturn { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost;Database=Kroells_Bank;User=sa;Password=Kode1234!;Encrypt=False;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Account>(entity =>
        {
            entity.HasKey(e => e.AccountId).HasName("PK__Accounts__B19E45E95FAB15EA");

            entity.Property(e => e.AccountId).HasColumnName("Account_Id");
            entity.Property(e => e.CardId).HasColumnName("Card_Id");

            entity.HasOne(d => d.Card).WithMany(p => p.Accounts)
                .HasForeignKey(d => d.CardId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Accounts__Card_I__477199F1");
        });

        modelBuilder.Entity<Address>(entity =>
        {
            entity.HasKey(e => e.AddressId).HasName("PK__Addresse__03BDEBBA8D905711");

            entity.Property(e => e.AddressId).HasColumnName("Address_Id");
            entity.Property(e => e.City)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.HouseNr).HasColumnName("House_Nr");
            entity.Property(e => e.Street)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.ZipCode).HasColumnName("Zip_Code");
        });

        modelBuilder.Entity<Card>(entity =>
        {
            entity.HasKey(e => e.CardId).HasName("PK__Cards__45AA4B6339D071E2");

            entity.Property(e => e.CardId).HasColumnName("Card_Id");
            entity.Property(e => e.CardNr)
                .HasMaxLength(16)
                .IsUnicode(false)
                .HasColumnName("Card_Nr");
            entity.Property(e => e.ClientName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Client_Name");
            entity.Property(e => e.Cvv).HasColumnName("CVV");
            entity.Property(e => e.ExpireDate)
                .HasColumnType("date")
                .HasColumnName("Expire_Date");
            entity.Property(e => e.SpendingLimit).HasColumnName("Spending_Limit");
        });

        modelBuilder.Entity<Client>(entity =>
        {
            entity.HasKey(e => e.ClientId).HasName("PK__Clients__75A5D8F8964D512E");

            entity.Property(e => e.ClientId).HasColumnName("Client_Id");
            entity.Property(e => e.ClientName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Client_Name");
            entity.Property(e => e.PasswordHashed)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<ClientAccount>(entity =>
        {
            entity.HasKey(e => e.ClientAccountId).HasName("PK__Client_A__7B12944DA3C74C03");

            entity.ToTable("Client_Account");

            entity.Property(e => e.ClientAccountId).HasColumnName("Client_Account_Id");
            entity.Property(e => e.AccountId).HasColumnName("Account_Id");
            entity.Property(e => e.ClientId).HasColumnName("Client_Id");

            entity.HasOne(d => d.Account).WithMany(p => p.ClientAccounts)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Client_Ac__Accou__5006DFF2");

            entity.HasOne(d => d.Client).WithMany(p => p.ClientAccounts)
                .HasForeignKey(d => d.ClientId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Client_Ac__Clien__4F12BBB9");
        });

        modelBuilder.Entity<ClientJob>(entity =>
        {
            entity.HasKey(e => e.ClientJobId).HasName("PK__Client_J__4ED9F646347193A4");

            entity.ToTable("Client_Job");

            entity.Property(e => e.ClientJobId).HasColumnName("Client_Job_Id");
            entity.Property(e => e.ClientId).HasColumnName("Client_Id");
            entity.Property(e => e.JobId).HasColumnName("Job_Id");

            entity.HasOne(d => d.Client).WithMany(p => p.ClientJobs)
                .HasForeignKey(d => d.ClientId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Client_Jo__Clien__603D47BB");

            entity.HasOne(d => d.Job).WithMany(p => p.ClientJobs)
                .HasForeignKey(d => d.JobId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Client_Jo__Job_I__61316BF4");
        });

        modelBuilder.Entity<Cpr>(entity =>
        {
            entity.HasKey(e => e.CprId).HasName("PK__CPRs__D3C1F31E95CF0F61");

            entity.ToTable("CPRs");

            entity.Property(e => e.CprId).HasColumnName("CPR_Id");
            entity.Property(e => e.AddressId).HasColumnName("Address_Id");
            entity.Property(e => e.ClientId).HasColumnName("Client_Id");
            entity.Property(e => e.CprNr)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("CPR_Nr");
            entity.Property(e => e.EmployeeId).HasColumnName("Employee_Id");

            entity.HasOne(d => d.Address).WithMany(p => p.Cprs)
                .HasForeignKey(d => d.AddressId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__CPRs__Address_Id__57A801BA");

            entity.HasOne(d => d.Client).WithMany(p => p.Cprs)
                .HasForeignKey(d => d.ClientId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__CPRs__Client_Id__56B3DD81");

            entity.HasOne(d => d.Employee).WithMany(p => p.Cprs)
                .HasForeignKey(d => d.EmployeeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__CPRs__Employee_I__589C25F3");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.EmployeeId).HasName("PK__Employee__781134A1AA37A5C8");

            entity.Property(e => e.EmployeeId).HasColumnName("Employee_Id");
            entity.Property(e => e.PasswordHashed)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Position)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Job>(entity =>
        {
            entity.HasKey(e => e.JobId).HasName("PK__Jobs__E76A76A62947EE24");

            entity.Property(e => e.JobId).HasColumnName("Job_Id");
            entity.Property(e => e.JobName)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("Job_Name");
        });

        modelBuilder.Entity<Loan>(entity =>
        {
            entity.HasKey(e => e.LoanId).HasName("PK__Loans__937E27B3564A9D89");

            entity.Property(e => e.LoanId).HasColumnName("Loan_Id");
            entity.Property(e => e.Apr).HasColumnName("APR");
            entity.Property(e => e.ClientId).HasColumnName("Client_Id");

            entity.HasOne(d => d.Client).WithMany(p => p.Loans)
                .HasForeignKey(d => d.ClientId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Loans__Client_Id__5B78929E");
        });

        modelBuilder.Entity<Transaction>(entity =>
        {
            entity.HasKey(e => e.TransactionId).HasName("PK__Transact__9A8D5605A1F217B4");

            entity.Property(e => e.TransactionId).HasColumnName("Transaction_Id");
            entity.Property(e => e.AccountId).HasColumnName("Account_Id");
            entity.Property(e => e.DateTime)
                .HasColumnType("datetime")
                .HasColumnName("Date_Time");

            entity.HasOne(d => d.Account).WithMany(p => p.Transactions)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Transacti__Accou__4A4E069C");
        });

        OnModelCreatingPartial(modelBuilder);
        modelBuilder.Entity<LoginReturn>().HasNoKey();
        modelBuilder.Entity<CardInfo>().HasNoKey();
        modelBuilder.Entity<ClientInformation>().HasNoKey();
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
