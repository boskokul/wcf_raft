# schneider_internship
This is a simple client-server app designed with the goal to implement the RAFT Consensus Algorithm. 

App was made using .Net framework. WCF should be installed to be able to run the app.

##

In order to run the app multiple startup projects should be set as shown:

![image](https://github.com/dusan-sudjic/schneider_internship/assets/116630727/d29eb5c1-e984-449c-b9cd-9e682fd09503)


There are 3 servers (endpoints) that communicate in such a way that they all have a specific time after which they apply for a leader. When time runs out on one of the servers, the server votes for itself and sends a request to others asking them to vote. After the server has received at least one vote other than its own vote, it can declare itself the leader and announce this to the other two. After each period, it sends a keep-alive message to the non-leader servers.
The client can shut down the leading server and then the process starts over, but without that one server.

The result should look like this:

![image](https://github.com/dusan-sudjic/schneider_internship/assets/116630727/18ae4d9c-db31-4661-9102-1aecee44ba7e)



## Authors

- [@boskokul](https://www.github.com/boskokul)
- [@dusan-sudjic](https://github.com/dusan-sudjic)
- Menthor: Ph.D. Mita Cokic, Schneider Electric DMS NS

