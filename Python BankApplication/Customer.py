from Account import Account


class Customer:
    currentid = 111111
    
    def __init__(self, name, securitynumber):
        
        self.id = Customer.currentid
        self.name = name
        self.securitynumber = securitynumber
        self.accounts = [Account()]
        
        Customer.currentid += 1

    
    


        

