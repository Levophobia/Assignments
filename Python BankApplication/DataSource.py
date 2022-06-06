from Customer import Customer
from Account import Account

class DataSource:
       
    customers = []

    def datasource_conn(self):
        f = open("BankApplication/Data.txt")
        true = True
        string = "Connection successfull"
        name = f.name
        tuple = (true, string, name)
        f.close()
        return tuple

    def get_all(self):
        
        f = open("BankApplication/Data.txt", mode = "rt")
        lines = sum(1 for line in open('BankApplication/Data.txt'))
         
        
        for x in range(lines):
            string = f.readline()
            hashtags = string.count("#")
            replace = string.replace("#", ":")
            text = replace.split(":")            
            customer = Customer(text[1], text[2])
            customer.accounts[0].balance = float(text[5])
            
            eight = 8
            for x in range(hashtags):
                
                account = Account()
                account.balance = float(text[eight])
                customer.accounts.append(account)
                eight += 3
            
            self.customers.append(customer)
            
        f.close()
        return self.customers

    def update_by_id(self, id):
        
        customerinfo = []
        customerstring = ""        

        for x in range(len(self.customers)):
            if id == self.customers[x].id:
                customerinfo.append(self.customers[x].id)
                customerinfo.append(self.customers[x].name)
                customerinfo.append(self.customers[x].securitynumber)
                for y in range(len(self.customers[x].accounts)):
                    customerinfo.append(self.customers[x].accounts[y].accountnumber)
                    customerinfo.append(self.customers[x].accounts[y].accounttype)
                    customerinfo.append(self.customers[x].accounts[y].balance)
                
                customerstring = str(customerinfo[0]) + ":" + str(customerinfo[1]) + ":" + str(customerinfo[2]) + ":"
                customerstring += str(customerinfo[3]) + ":" + str(customerinfo[4]) + ":" + str(customerinfo[5])
                
                
                six = 6              
                for y in range(1, len(self.customers[x].accounts)):
                    customerstring += "#" + str(customerinfo[six]) + ":" + str(customerinfo[six + 1]) + ":" + str(customerinfo[six + 2])
                    six += 3
                    
        
        
        f = open("BankApplication/Data.txt", mode = "rt")
        lines = sum(1 for line in open('BankApplication/Data.txt'))
        
        listoflines = f.readlines()
        f.seek(0)
                  
        for x in range(lines):            
            string = f.readline()            
            text = string.split(":")            
            if id == int(text[0]):               
                listoflines[x] = customerstring +"\n"
                f = open("BankApplication/Data.txt", mode = "wt")
                f.writelines(listoflines)
                f.close()
                break
        else: return -1
                                       
        return customerstring


    def find_by_id(self, id):

        f = open("BankApplication/Data.txt", mode = "rt")
        lines = sum(1 for line in open('BankApplication/Data.txt'))
        for x in range(lines):
            string = f.readline()            
            text = string.split(":")            
            if id == int(text[0]):
                return string
        f.close()
        return -1


    def remove_by_id(self, id):
        f = open("BankApplication/Data.txt", mode = "rt")
        lines = sum(1 for line in open('BankApplication/Data.txt'))
        listoflines = f.readlines()
        f.seek(0)
        
        
        for x in range(lines):            
            string = f.readline()            
            text = string.split(":")
            
                     
            if id == int(text[0]):
                del listoflines[x]
                f = open("BankApplication/Data.txt", mode = "wt")
                f.writelines(listoflines)
                f.close()
                break 
        else: return -1
                                       
        return string

        




        



        
                

            
            
        




        



        