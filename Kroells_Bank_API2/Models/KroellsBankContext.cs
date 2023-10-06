using System;
using System.Collections.Generic;
using Kroells_Bank_API.Models;
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
            entity.HasKey(e => e.AccountId).HasName("PK__Accounts__B19E45E98BD2F888");

            entity.Property(e => e.AccountId).HasColumnName("Account_Id");
            entity.Property(e => e.CardId).HasColumnName("Card_Id");

            entity.HasOne(d => d.Card).WithMany(p => p.Accounts)
                .HasForeignKey(d => d.CardId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Accounts__Card_I__46B27FE2");
        });

        modelBuilder.Entity<Address>(entity =>
        {
            entity.HasKey(e => e.AddressId).HasName("PK__Addresse__03BDEBBAE64B6B17");

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
            entity.HasKey(e => e.CardId).HasName("PK__Cards__45AA4B63304EF407");

            entity.Property(e => e.CardId).HasColumnName("Card_Id");
            entity.Property(e => e.CardNr).HasColumnName("Card_Nr");
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
            entity.HasKey(e => e.ClientId).HasName("PK__Clients__75A5D8F8A1D94068");

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
            entity.HasKey(e => e.ClientAccountId).HasName("PK__Client_A__7B12944D691388C4");

            entity.ToTable("Client_Account");

            entity.Property(e => e.ClientAccountId).HasColumnName("Client_Account_Id");
            entity.Property(e => e.AccountId).HasColumnName("Account_Id");
            entity.Property(e => e.ClientId).HasColumnName("Client_Id");

            entity.HasOne(d => d.Account).WithMany(p => p.ClientAccounts)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Client_Ac__Accou__4F47C5E3");

            entity.HasOne(d => d.Client).WithMany(p => p.ClientAccounts)
                .HasForeignKey(d => d.ClientId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Client_Ac__Clien__4E53A1AA");
        });

        modelBuilder.Entity<ClientJob>(entity =>
        {
            entity.HasKey(e => e.ClientJobId).HasName("PK__Client_J__4ED9F646A84F738C");

            entity.ToTable("Client_Job");

            entity.Property(e => e.ClientJobId).HasColumnName("Client_Job_Id");
            entity.Property(e => e.ClientId).HasColumnName("CLient_Id");
            entity.Property(e => e.JobId).HasColumnName("Job_Id");

            entity.HasOne(d => d.Client).WithMany(p => p.ClientJobs)
                .HasForeignKey(d => d.ClientId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Client_Jo__CLien__5F7E2DAC");

            entity.HasOne(d => d.Job).WithMany(p => p.ClientJobs)
                .HasForeignKey(d => d.JobId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Client_Jo__Job_I__607251E5");
        });

        modelBuilder.Entity<Cpr>(entity =>
        {
            entity.HasKey(e => e.CprId).HasName("PK__CPRs__D3C1F31E1514F348");

            entity.ToTable("CPRs");

            entity.Property(e => e.CprId).HasColumnName("CPR_Id");
            entity.Property(e => e.AddressId).HasColumnName("Address_Id");
            entity.Property(e => e.ClientId).HasColumnName("Client_Id");
            entity.Property(e => e.CprNr).HasColumnName("CPR_Nr");
            entity.Property(e => e.EmployeeId).HasColumnName("Employee_Id");

            entity.HasOne(d => d.Address).WithMany(p => p.Cprs)
                .HasForeignKey(d => d.AddressId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__CPRs__Address_Id__56E8E7AB");

            entity.HasOne(d => d.Client).WithMany(p => p.Cprs)
                .HasForeignKey(d => d.ClientId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__CPRs__Client_Id__55F4C372");

            entity.HasOne(d => d.Employee).WithMany(p => p.Cprs)
                .HasForeignKey(d => d.EmployeeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__CPRs__Employee_I__57DD0BE4");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.EmployeeId).HasName("PK__Employee__781134A1D0E129CF");

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
            entity.HasKey(e => e.JobId).HasName("PK__Job__E76A76A6736CEE6B");

            entity.ToTable("Job");

            entity.Property(e => e.JobId).HasColumnName("Job_Id");
            entity.Property(e => e.JobName)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("Job_Name");
        });

        modelBuilder.Entity<Loan>(entity =>
        {
            entity.HasKey(e => e.ClientAccountId).HasName("PK__Loans__7B12944D2DDBECEC");

            entity.Property(e => e.ClientAccountId).HasColumnName("Client_Account_Id");
            entity.Property(e => e.Apr).HasColumnName("APR");
            entity.Property(e => e.ClientId).HasColumnName("Client_Id");

            entity.HasOne(d => d.Client).WithMany(p => p.Loans)
                .HasForeignKey(d => d.ClientId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Loans__Amount__5AB9788F");
        });

        modelBuilder.Entity<Transaction>(entity =>
        {
            entity.HasKey(e => e.TransactionId).HasName("PK__Transact__9A8D5605BE5ECDBF");

            entity.Property(e => e.TransactionId).HasColumnName("Transaction_Id");
            entity.Property(e => e.AccountId).HasColumnName("Account_Id");
            entity.Property(e => e.DateTime)
                .HasColumnType("datetime")
                .HasColumnName("Date_Time");

            entity.HasOne(d => d.Account).WithMany(p => p.Transactions)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Transacti__Accou__498EEC8D");
        });
        OnModelCreatingPartial(modelBuilder);

        modelBuilder.Entity<ClientInformation>().HasNoKey();
        modelBuilder.Entity<CardInfo>().HasNoKey();
        modelBuilder.Entity<LoginReturn>().HasNoKey();
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
