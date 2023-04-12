import os
import sys
from dotenv import load_dotenv
from MigrationUtils import MigrationUtils


class DatabaseCleaner:

    def __init__(self) -> None:
        load_dotenv()
        self.utils = MigrationUtils()
        self.origin_env = os.environ.copy()

    def run(self):
        if not sys.argv or len(sys.argv) != 2:
            print()
            print("ERROR...")
            print("USAGE: {0} <project_name>".format(
                os.path.basename((__file__))))
            print()
            exit(-1)

        project_name = sys.argv[1]
        db_name = os.getenv("DB_DATABASE")

        print("script started: {0}...".format(os.path.basename((__file__))))
        print("MODE: {0}".format(os.getenv("mode")))
        print("project: {0}".format(project_name))

        conn = self.utils.getConnection(db_name)
        try:
            query = "SELECT * FROM pg_catalog.pg_tables WHERE schemaname != 'information_schema' AND schemaname != 'pg_catalog';"
            data = self.utils.fetchData(conn, query)
            for row in data:
              delete_query = "DROP TABLE \"{0}\" CASCADE;".format(row[1])
              print(delete_query)
              self.utils.execute(conn, delete_query)

        except Exception as err:
            print("ERROR occurred during cleaning database!")
            print(err)
        finally:
            conn.close()


if __name__ == "__main__":
    runner = DatabaseCleaner()
    runner.run()
