import glob
import os
from dotenv import dotenv_values
import psycopg2


class MigrationUtils:

    def __init__(self) -> None:
        pass

    def getConnection(self, db_name: str):
        return psycopg2.connect(
            database=db_name,
            user=os.getenv("DB_USERNAME"),
            password=os.getenv("DB_PASSWORD"),
            host=os.getenv("DB_HOST"),
            port=os.getenv("DB_PORT")
        )

    def find_datasource(self, project_name):
        path_to_search = './libs/server/{}/**/connector.ts'.format(
            project_name)
        path = glob.glob(path_to_search, recursive=True)
        return path[0]

    def find_migration_folder(self, project_name):
        migrations_path = './libs/server/{}/src/lib/migrations'.format(
            project_name)
        return migrations_path

    def createDb(self, conn: any, db_name: str):
        conn.autocommit = True
        sql = "CREATE database \"{}\"".format(db_name)

        with conn.cursor() as curs:
            curs.execute(sql)
            conn.commit()

        print("Database {} created!".format(db_name))

    def deleteDb(self, conn: any, db_name: str):
        conn.autocommit = True
        sql = "DROP database \"{}\"".format(db_name)

        with conn.cursor() as curs:
            curs.execute(sql)
            conn.commit()

        print("Database {} deleted!".format(db_name))

    def runMigrations(self, data_source: str, db_name: str):
        new_env = os.environ.copy()
        new_env = dotenv_values()

        new_env["DB_DATABASE"] = db_name
        command = "yarn typeorm migration:run -d \"{0}\" ".format(data_source)

        print("executing: {}".format(command))
        os.environ["DB_DATABASE"] = db_name
        output = os.popen(command)
        print(output.read())

    def createMigrations(self, data_source_path: str, migrations_path: str, migration_name: str, db_name: str):
        new_env = os.environ.copy()
        new_env = dotenv_values()

        new_env["DB_DATABASE"] = db_name
        command = "yarn typeorm migration:generate -d \"{0}\" \"{1}\"".format(
            data_source_path, os.path.join(migrations_path, migration_name))

        os.environ["DB_DATABASE"] = db_name
        output = os.popen(command)
        print(output.read())

    def fetchData(self, conn, query):
      result = None
      with conn.cursor() as curs:
            curs.execute(query)
            result = curs.fetchall()

      return result

    def execute(self, conn, query):
      result = None
      with conn.cursor() as curs:
            curs.execute(query)
            conn.commit()

      return result
