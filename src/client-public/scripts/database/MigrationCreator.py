import os
import sys
from dotenv import load_dotenv
import uuid
from MigrationUtils import MigrationUtils

class MigrationCreator:

    def __init__(self) -> None:
        load_dotenv()
        self.utils = MigrationUtils()
        self.origin_env = os.environ.copy()


    def run(self):
        if not sys.argv or len(sys.argv) != 3:
            print()
            print("ERROR...")
            print("USAGE: {0} <project_name> <migration_name>".format(
                os.path.basename((__file__))))
            print()
            exit(-1)

        db_name = str(uuid.uuid4())
        project_name = sys.argv[1]
        migration_name = sys.argv[2]

        print("script started: {0}...".format(os.path.basename((__file__))))
        print("MODE: {0}".format(os.getenv("mode")))
        print("project: {0}".format(project_name))
        print("migration: {0}".format(migration_name))

        conn = self.utils.getConnection(self.origin_env["DB_DATABASE"])
        try:
            self.utils.createDb(conn, db_name)

            data_source_path = self.utils.find_datasource(project_name)
            print("DATA SOURCE: {}".format(data_source_path))
            self.utils.runMigrations(data_source_path, db_name)

            migrations_path = self.utils.find_migration_folder(project_name)
            self.utils.createMigrations(data_source_path, migrations_path,
                             migration_name, db_name)

        except Exception as err:
            print("ERROR occurred during creating migrations!")
            print(err)
        finally:
            self.utils.deleteDb(conn, db_name)
            conn.close()


if __name__ == "__main__":
    creator = MigrationCreator()
    creator.run()
