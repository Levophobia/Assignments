class Account:
    
    currentnumber = 1001

    def __init__(self):
        self.accountnumber = Account.currentnumber
        self.accounttype = "debit account"
        self.balance = 0
        
        Account.currentnumber += 1


    


