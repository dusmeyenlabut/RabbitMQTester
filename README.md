## Installation
You must install RabbitMQ before you start to use app.

You must create these environment variables before you start the app.
Linux Base environments
```sh
export RABBITMQHOST="myhostname"
export RABBITPASSWORD="myusername"
export RABBITUSERNAME="mysupersecretpassword"
```

```sh
git clone https://github.com/bingolburak/NetCoreTestAPIController.git
```

```sh
dotnet restore
dotnet run
```



## Usage
The service has only one method that is sendMessage

You should call the https://hostname:port/automatapi/v1/sendMessage

You should see "Message was published" messege as result.

