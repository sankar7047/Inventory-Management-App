# Inventory-Management-App

- Overview:  
   - A client-server application that allows the user to select from Products in an Inventory and assign them to an Order. The client will have two main screens: one to see an overview of the Products in the Inventory, and another to build an order from Products in the Inventory. Even though the requirements describe an extremely simple application, you are encouraged to use techniques and methodologies that you feel should be used in production software.  

- Minimum Requirements: 
   - The client must be implemented using MVVM / WPF :  
   - The Inventory overview screen shows all Products and their current quantity. 
   - These Products must be obtained from the server at startup. 
   - The Inventory overview screen must open when the application runs and remain visible at all times. 
   - The Order screen allows the user to choose quantities of Products from Inventory and add that quantity to the Order. 
   - User must be able to create and work on more than one order simultaneously. 
   - The Inventory overview screen must respond appropriately to users adding quantities of Products to Orders. 

- The server must be implemented using WCF: 
   - All operations must implement a 1500 millisecond delay before returning to simulate less-than-ideal network conditions. 
   - DO NOT involve the use of a database, but rather simulate persisted data.
