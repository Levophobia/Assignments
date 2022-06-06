from Account import Account
from Customer import Customer
from DataSource import DataSource
from Transaction import Transaction

class Bank:

    ds = DataSource()
    def __init__(self):
        
        print("")
        print(self.ds.datasource_conn())
        self.customers = self.ds.get_all()
        self.transactions = []

    
    def get_customers(self):
        customernumberandname = []
        for x in range(len(self.customers)):
            customernumberandname.append(self.customers[x])
        return customernumberandname
            

    def add_customer(self, name, pnr): 
            newcustomer = Customer(name, pnr)
            for x in range(len(self.customers)):
                if self.customers[x].securitynumber == pnr:
                    return False
                    
            self.customers.append(newcustomer)
            return True 

    def get_customer(self, pnr):
        customerinfo = []
        for x in range(len(self.customers)):
            if pnr == self.customers[x].securitynumber:
                customerinfo.append(self.customers[x].securitynumber)
                customerinfo.append(self.customers[x].name)
                for y in range(len(self.customers[x].accounts)):
                    customerinfo.append([self.customers[x].accounts[y].accountnumber, self.customers[x].accounts[y].accounttype, self.customers[x].accounts[y].balance])
                return customerinfo
        return -1
        
                    

        

    def change_customer_name(self, name, pnr):
        for x in range(len(self.customers)):
            if pnr == self.customers[x].securitynumber:
                self.customers[x].name = name
                return True
                
                
        return False

    def remove_customer(self, pnr):
        removed = []
        for x in range(len(self.customers)):
            if pnr == self.customers[x].securitynumber:                
                removed = self.customers[x].accounts
                
                self.customers.pop(x)
                print("The following accounts were removed:")
                return removed
        return -1

    def add_account(self, pnr):
        for x in range(len(self.customers)):
            if pnr == self.customers[x].securitynumber:
                self.customers[x].accounts.append(Account())
                return True
                
        return False

    def get_account(self, pnr, accountid):       
        for x in range(len(self.customers)):
            if pnr == self.customers[x].securitynumber:
                for y in range(len(self.customers[x].accounts)):
                    if accountid == self.customers[x].accounts[y].accountnumber:
                        return self.customers[x].accounts[y]
        return -1

    def deposit(self, pnr, account_id, amount):
        
        for x in range(len(self.customers)):
            if self.customers[x].securitynumber == pnr:
                customerid = self.customers[x].id
           
        for x in range(len(self.customers)):
            if pnr == self.customers[x].securitynumber:                
                for y in range(len(self.customers[x].accounts)):
                    if account_id == self.customers[x].accounts[y].accountnumber:
                        self.customers[x].accounts[y].balance += amount
                        
                        ta = Transaction(customerid, account_id, amount)
                        self.transactions.append(ta)
                        return True
                    else: return False
                    
            

    def withdraw(self,pnr, account_id, amount):

        for x in range(len(self.customers)):
            if self.customers[x].securitynumber == pnr:
                customerid = self.customers[x].id

        for x in range(len(self.customers)):
            if pnr == self.customers[x].securitynumber:
                for y in range(len(self.customers[x].accounts)):
                    if account_id == self.customers[x].accounts[y].accountnumber:
                        if self.customers[x].accounts[y].balance > amount:
                            self.customers[x].accounts[y].balance -= amount
                            
                            ta = Transaction(customerid, account_id, -amount)
                            self.transactions.append(ta)
                            return True
                        else: return False


    def close_account(self, pnr, account_id):
        info = Account()

        for x in range(len(self.customers)):
            if self.customers[x].securitynumber == pnr:
                for y in range(len(self.customers[x].accounts)):
                    if self.customers[x].accounts[y].accountnumber == account_id:
                        info = self.customers[x].accounts[y]
                        self.customers[x].accounts.pop(y)
                        return info
        return -1 

    def updatebyid(self, id):
        customer = self.ds.update_by_id(id)
        return customer

    def findbyid(self, id):
        customer = self.ds.find_by_id(id)
        return customer

    def deletebyid(self, id):
        customer = self.ds.remove_by_id(id)
        return customer

    
    def get_all_transactions_by_pnr_acc_nr(self, pnr, acc_nr ):
        listoftransactions = []

        number = 0
        for x in range(len(self.customers)):
            if self.customers[x].securitynumber == pnr:
                for y in range(len(self.customers[x].accounts)):
                    if self.customers[x].accounts[y].accountnumber == acc_nr:
                        number = -1
        
        if number == 0:
            return -1

        for x in range(len(self.transactions)):
            if acc_nr == self.transactions[x].accountnumber:
                string = "Date: " + str(self.transactions[x].date) + " Amount: " + str(self.transactions[x].amount)
                listoftransactions.append(string)
            

        return listoftransactions
            




        





                

            

                 
        