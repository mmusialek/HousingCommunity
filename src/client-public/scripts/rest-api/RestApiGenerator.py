import os
import sys
from dotenv import load_dotenv


class RestApiGenerator:

    def __init__(self) -> None:
        load_dotenv()
        self.origin_env = os.environ.copy()

    def run(self):
        # if not sys.argv or len(sys.argv) != 1:
        #     print()
        #     print("ERROR...")
        #     print("USAGE: {0} <project_name>".format(
        #         os.path.basename((__file__))))
        #     print()
        #     exit(-1)

        print("script started: {0}...".format(os.path.basename((__file__))))
        print("MODE: {0}".format(os.getenv("mode")))
        print("dir: {0}".format(os.getcwd()))

        try:
          apiUrl = "http://localhost:3333/api-docs-json"
          projectUrl = "libs\client\communication\src\lib\RestApi"
          command = "yarn openapi-generator-cli generate -i {0} -c scripts/rest-api/config.yaml -g typescript-fetch -o {1} --skip-validate-spec".format(apiUrl, projectUrl)
          output = os.popen(command)
          print(output.read())

        except Exception as err:
            print("ERROR occurred during generating REST API classes!")
            print(err)


if __name__ == "__main__":
    runner = RestApiGenerator()
    runner.run()
