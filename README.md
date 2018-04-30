# Gummi Bear Kingdom

##### A website for Gummi Bear Kingdom company. 4/27/2018

## By Frank Ngo

# Description
This website currently allows users to add new items to the website inventory. Users may create, edit, and delete items. In the future, they will be able to add reviews well.

## Current Specs
* Program should have a home landing page from where user can go see a list of items
	* Input: User arrives on the home pages
	* Output: List of items as well as a nav bar to navigate through adding new items
* Program should list all available items
	* Input: User arrives on list of items page
	* Output: A list of items
* An user should be able to add new items
	* Input: Name, Description, and Cost information
	* Output: A new item object in the database
* A user should be able to click on each item and see details
	* Input: User clicks a item/link to details page.
	* Output: Details for that item via item id
* An user should be able to edit an item's information
	* Input: User clicks "edit" on an item
	* Output: User is taken to a form where they can edit the Name, Description, and Cost of the item
  * An user should be able to remove an item
	* Input: user clicks delete on an item
	* Output: User is first presented with a confirmation page, and then the option to follow through with deletion


## Technologies Used
* Bootstrap
* C#/ASP.NET
* Entity Framework
* MySql/MAMP

## Setup/Installation Instructions
  * Clone the GitHub repository:
  ```
  $ git clone https://github.com/FrankNgo/GummiBear
  ```

  * Install the .NET Framework and MAMP

    .NET Core 1.1 SDK (Software Development Kit)
    .NET runtime.
    MAMP

    See https://www.learnhowtoprogram.com/c/getting-started-with-c/installing-c for instructions and links.

* Start the Apache and MySql Servers in MAMP. Make sure you use the default port settings for Apache and MySql (8888 and 8889, respectively)

* `cd GummiBear/GummiBear`

*  Setup the database

  ```
  $ dotnet ef database update
  ```
*  Restore dependencies and run the program
  ```
  $ dotnet restore
  $ dotnet run
  ```

### License

*MIT License*

Copyright (c) 2018 **_Frank Ngo_**

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
