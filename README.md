# schneider_internship
This is a simple client-server app designed with the goal to implement the RAFT Consensus Algorithm. 

App was made using .Net framework. WCF should be installed to be able to run the app.

## Screenshots

In order to run the app multiple startup projects should be set as shown:

![image](https://github.com/boskokul/oisisi-v2.0/assets/116630727/9a9d71bd-f485-4daa-8dcd-822be35ad1e7)



There are 3 servers which communicate in the way that first one calls two others and gets one number by each of them and then multiplies them together with a number sent from client. 
Server then returns the result to the clinet who sent a request.
The result should look like this:

![image](https://github.com/boskokul/oisisi-v2.0/assets/116630727/9853afcd-da9e-4f83-9335-c57bd25bd8a3)


## Authors

- [@boskokul](https://www.github.com/boskokul)
- [@dusan-sudjic](https://github.com/dusan-sudjic)
- Menthor: Mita Cokic, Schneider Electric DMS NS

