import os
import sys
from dotenv import load_dotenv
from MigrationUtils import MigrationUtils


class MigrationRunner:

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

        print("script started: {0}...".format(os.path.basename((__file__))))
        print("MODE: {0}".format(os.getenv("mode")))
        print("project: {0}".format(project_name))

        conn = self.utils.getConnection(os.getenv("DB_DATABASE"))
        try:

            data_source_path = self.utils.find_datasource(project_name)
            print("DATA SOURCE: {}".format(data_source_path))
            self.utils.runMigrations(data_source_path, self.origin_env["DB_DATABASE"])

        except Exception as err:
            print("ERROR occurred during running migrations!")
            print(err)
        finally:
            conn.close()


if __name__ == "__main__":
    runner = MigrationRunner()
    runner.run()
