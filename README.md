# P03domainmodels

> P03 Domain Models domain modeling using entity framework code first with SqlServer and Postgres

## Development

### Build watchers

Build and run command line application of file change

```bash
dotnet watch run
```

Build with automatic unit test execution

```bash
dotnet watch test
```

## Stories

### Main Story



See all [stories](./STORIES.md)


## Usage

See all [usage examples](./USAGE.md)


### My Local Development Setup

#### Global Tools

Note, you only need to load these once

```bash
# Tooling for entity framework 4
dotnet tool install --global dotnet-ef

# dotnet-format is a code formatter for dotnet that applies style preferences to a project or solution
dotnet tool install -g dotnet-format

```

#### Docker compose for MsSQL 2019 and Postres 13

```bash
cd ~/dev/docker
# Run locally (if you need to test, otherwise)
docker compose up
# Run detached
docker compose up -d

# logs from docker folder
docker-compose logs -f pg13
docker-compose logs -f mssql2019
```

#### Need to check logs from other development folder?

```
docker logs -f pg13
docker logs -f mssql2019
```

#### Connect to Postgres

```bash
docker-compose exec -u postgres pg13 bash

# Drop database (from bash)
dropdb 'P03'

# Start PSQL runtime
psql

# List of databases (from psql)
\l
```

#### Connect to MsSQL

```bash
docker exec -it mssql2019 "bash"

/opt/mssql-tools/bin/sqlcmd -S localhost -U SA -P '[Password]'

# List databases
SELECT Name from sys.Databases
GO

# Drop database from command line
DROP DATABASE P03;
GO
```

#### need to check environment?

```
docker exec -it pg13 env
```

### Add/update migrations

```bash
dotnet ef migrations add Initial --context DbMsContext
dotnet ef migrations add Initial --context DbPgContext

dotnet ef database update --context DbMsContext
dotnet ef database update --context DbPgContext

dotnet ef migrations add AddRelations --context DbMsContext
dotnet ef migrations add AddRelations --context DbPgContext

dotnet ef database update --context DbMsContext
dotnet ef database update --context DbPgContext
````

## Contributing

Bug reports and pull requests are welcome on GitHub at https://github.com/klueless-io/P03DomainModels. This project is intended to be a safe, welcoming space for collaboration, and contributors are expected to adhere to the [Contributor Covenant](http://contributor-covenant.org) code of conduct.

## License

The gem is available as open source under the terms of the [MIT License](https://opensource.org/licenses/MIT).

## Code of Conduct

Everyone interacting in the P03domainmodels project’s codebases, issue trackers, chat rooms and mailing lists is expected to follow the [code of conduct](https://github.com/klueless-io/P03DomainModels/blob/master/CODE_OF_CONDUCT.md).

## Copyright

Copyright (c) David Cruwys. See [MIT License](LICENSE.txt) for further details.
