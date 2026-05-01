# OrderNotificationApp

## Description
Simple console app to simulate placing an order and notifying services using Events and Delegates.

## Features
- Notify multiple services (Email, SMS)
- Uses Events and Delegates
- Uses Lambda Expression
- Uses Extension Method
- Uses Func for filtering orders

## Where things are used

- Delegate:
  Action<Order> in OrderService

- Event:
  OrderDone event to notify subscribers

- Lambda:
  Used in App class for logging

- Extension Method:
  Print() method to format order data

- Func:
  Used to filter orders before sending notifications
