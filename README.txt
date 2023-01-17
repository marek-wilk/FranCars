This is web app that represents second hand car shop.
This app:
* Reads Warehouse and Vehicles related data from file and saves it to database
* API Endpoints: 
  - [GET] /vehicle - returns all vehicles
  - [GET] /vehicle/{id} - returns VehicleViewModel by vehicle id
  - [GET] /shoppingCart/userId={userId} - returns cart of a user with specified Id
  - [POST] /shoppingCart/addItem - adds item to the cart
  - [POST] /auth/register - creates new user
  - [POST] /auth/login - gets user from repository by email, verifies password using BCrypt then generates jwt and appends it to newly created cookie
  - [GET] /auth/user - verifies jwt, gets user Id from inside, then gets user from repository and returns them
  - [DELETE] /auth/logout - removes cookie together with jwt
* React app shows all the Vehicles in the table on the main site. You can log in, check details of vehicles (alongside warehouse location on the map it is stored in), add them to cart and check your cart

Technologies/Languages/Frameworks used: C#, .NET Core, EF Core, React, BCrypt, JWT, Cookies, XUnit
