from datetime import datetime

class Transaction:
    number = 1
    def __init__(self, customerid, accountnumber, amount):
        
        self.transactionid = Transaction.number
        self.customerid = customerid
        self.accountnumber = accountnumber
        self.date = datetime.now().strftime("%Y-%m-%d %H:%M:%S")
        self.amount = amount

        Transaction.number += 1