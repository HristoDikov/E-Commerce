Documentation for E-commerce:

USER ENDPOINTS:

CREATE USER:

POST - https://localhost:44348/api/User/Register

{
	"username": "Test",
	"password": "123456",
	"currencyCode": "GBP"
}

Creates new user and returns that it is registered.

LOGIN:

POST - https://localhost:44348/api/User/Login

{
	"username": "Test",
	"password": "123456"
}

Logs the user and returns Jwt. Copy the JWT.

--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
PRODUCT ENDPOINTS:
 
 CREATE PRODUCT: 
 
 Authorize with your JWT.
 
 POST - https://localhost:44348/api/product
 
 {
	"name": "product",
	"price": "12",
	"image": "url"
}

Creates new product and returns that the product is created and its Id.


GET PRODUCT BY ID:

GET - https://localhost:44348/api/product/GetProductById?id=1

Gets the product with the selected id if it exists.

GET ALL PRODUCTS:

Get - https://localhost:44348/api/product

Gets all products.

DELETE PRODUCT:

DELETE - https://localhost:44348/api/product?id=1

Deletes product with selected Id.

--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

ORDER ENDPOINTS:

CREATE ORDER:

Authorize with your JWT.
 
POST - https://localhost:44348/api/order

Input - products Ids - [1, 2]

Creates the order and returns it with all its products.

GET USER ORDERS:

Authorize with  your JWT.

GET - https://localhost:44348/api/order/GetUserOrders

Gets user orders.

CHANGE ORDER STATUS:

Authorize with your JWT.

PUT - https://localhost:44348/api/order?id={orderId}&status={status}

Changes order status.


