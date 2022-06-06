from Bank import Bank

programrunning = True
bank = Bank()
CustomerList = bank.customers



while programrunning == True:
    print("")
    print("Choose from following options:")
    print("")
    print("Customers:")
    print("1. See all customers")
    print("2. Add new customer")
    print("3. Change customer's name")
    print("4. Delete customer")
    print("5. See all information on specific customer")
    print("")
    print("Accounts:")
    print("6. Withdraw money from account")
    print("7. Deopsit money to account")  
    print("8. Delete Account for existing customer")     
    print("9. See transaction history on specific account")
    print("10. Create Account for existing customer")
    print("")
    print("DataSource:")
    print("11. See information of specific account")
    print("12. Update Customer in DataSource")
    print("13. Find Customer in DataSource")
    print("14. Delete Customer from DataSource")
    print("")
    print("Exit:")
    print("15. Exit program")

    option = int(input()) 

    if option == 1:
        
        print("")
        customers = bank.get_customers()
        for x in range(len(customers)):
            print(f"id:{customers[x].id} ssn:{customers[x].securitynumber} name:{customers[x].name}")

        
        cont = str(input("continue..."))
            
    
    if option == 2:
        
        print("")
        newcustomername = input("Enter new customer's name: ")
        newcustomersecuritynumber = input("Enter new customer's securitynumber: ")
        print("")
        a = bank.add_customer(newcustomername, newcustomersecuritynumber)
        if a == True:
            print(f"New customer {newcustomername} was added")
        else:print("That securitynumber already exists")
        cont = str(input("continue..."))

        

    if option == 3:
        print("")
        changenamesecuritynumber = str(input("Enter the securitynumber of the customer that you wish to change the name of: "))
        changename = str(input("Enter the name you wish to change to: "))
        print("")
        a = bank.change_customer_name(changename, changenamesecuritynumber)
        if a == True:
            print("Name was changed")
        else: print("Something went wrong, name was not changed")
        cont = str(input("continue..."))
        

        

    if option == 10:
        print("")
        securitynumberaddaccount = str(input("Enter securitynumber of customer you wish to add an account for: "))
        print("")
        a = bank.add_account(securitynumberaddaccount)
        if a == True:
            print(f"Account was added for {securitynumberaddaccount}")
        else: print("Something went wrong, no account was added")
        cont = str(input("continue..."))      

    if option == 8:      
        print("")
        pnr = str(input("Securitynumber: ")) 
        deleteaccountnumber = int(input("Enter the accountnumber that you wish to delete: "))
        print("")
        
        accountinfo = bank.close_account(pnr, deleteaccountnumber)
        if accountinfo != -1:
            print(f"Account number {accountinfo.accountnumber} was closed")
            print(f"Remaining balance was: {accountinfo.balance}")
        else: print("Something went wron account was not closed")
        cont = str(input("continue...")) 

    if option == 9:

        print("")
        pnr = str(input("Securitynumber: "))
        acc_nr = int(input("Enter the accountnumber: "))
        print("")   
        transactions = bank.get_all_transactions_by_pnr_acc_nr(pnr, acc_nr)
        if transactions != -1:
            print(f"Transactions in accountnumber {acc_nr}:")
            for x in range(len(transactions)):
                print(transactions[x])
        else: print("Account was not found")
        cont = str(input("continue...")) 

    if option == 5:
        print("")
        pnr = str(input("Enter securitynumber of the customer of which you wish to view the information: "))
        print("")
        customerinformation = bank.get_customer(pnr)

        if customerinformation != -1:
            print(f"Securitynumber: {customerinformation[0]}")
            print(f"Name: {customerinformation[1]}")
            for x in range(2, len(customerinformation)):
                print(f"Accountnumber: {customerinformation[x][0]} Accounttype: {customerinformation[x][1]} Balance: {customerinformation[x][2]}")
        else:print("Customer was not found")

        cont = str(input("continue...")) 

    if option == 7:
        print("")
        pnr = str(input("Enter the securitynumber of the customer you wish to deposit to: "))
        account = int(input("Enter the account you wish to deposit to: "))
        amount = int(input("Enter the amount you wish to deposit: "))
        print("")
        insertedornot = bank.deposit(pnr, account, amount)
        if insertedornot == True:
            print(f"{amount} was deposited to {account}.")
        else:print("Something went wrong, no money was withdrawn")        
        cont = str(input("continue...")) 

    if option == 6:
        print("")
        pnr = str(input("Enter the securitynumber of the customer you wish to withdraw from: "))
        account = int(input("Enter the account you wish to withdraw from: "))
        amount = int(input("Enter the amount you wish to withdraw: "))
        print("")
        withdrawornot = bank.withdraw(pnr, account, amount)
        if withdrawornot == True:
            print(f"{amount} was withdrawn from {account}.")
        else:print("Something went wrong, no money was withdrawn")        
        cont = str(input("continue...")) 

    if option == 4:
        print("")
        pnr = str(input("Enter the securitynumber of the customer you wish to remove: "))
        print("")
        removedaccounts = bank.remove_customer(pnr)
        if removedaccounts != -1:
            for x in range(len(removedaccounts)):
                print("Customer was removed")
                print(f"Accountnumber: {removedaccounts[x].accountnumber} Accounttype: {removedaccounts[x].accounttype} Balance: {removedaccounts[x].balance}")
        else: print("Something went wrong, no customer was removed")
        cont = str(input("continue...")) 
    
    if option == 11:
        print("")
        pnr = str(input("Securitynumber: "))
        accountnumber = int(input("Accountnumber: "))
        print("")
        account = bank.get_account(pnr, accountnumber)
        if account != -1:
            print(f"Accountnumber: {account.accountnumber} Accounttype: {account.accounttype} Balance: {account.balance}")
        else:("Account was not found")
        cont = str(input("continue...")) 


    if option == 12:
        print("")
        idnumber = int(input("Enter id you wish to update: "))
        print("")
        customer = bank.updatebyid(idnumber)
        if customer != -1:
            print("Customer was updated")
            print(customer)
        else:print("Customer was not found")
        cont = str(input("continue...")) 

    if option == 13:
        print("")
        idnumber = int(input("Enter id you wish to find: "))
        print("")
        customer = bank.findbyid(idnumber)
        if customer != -1:
            print(customer)
        else:print("Customer was not found")
        cont = str(input("continue..."))

    if option == 14:
        print("")
        idnumber = int(input("Enter id you wish to delete from datasource: "))
        print("")
        customer = bank.deletebyid(idnumber)
        if customer != -1:
            print("The following customer was deleted from the datasource:")
            print(customer)
        else:print("The customer was not found")
        cont = str(input("continue..."))

    if option == 15:
        programrunning = False

        
    

    

    