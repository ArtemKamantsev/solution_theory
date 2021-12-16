# Run 'core' module
To be able to run any script from 'core' module you should perform following steps:
1. Install python. Insure it is installed and configured correctly 
(in cmd run ```python --version```, you should get result with version of python installed on your pc)
2. Go to 'core' folder
```cd ./core```
3. Create virtual environment
```python -m venv venv```
4. Activate environment (Windows)
```.\venv\Scripts\activate```
5. Install dependencies
```pip install -r requirements.txt```

# Run api.py
To start interaction with api you should execute command from 'core' folder:
```
.\venv\Scripts\python api.py
```
Following input should be performed via standard input stream.
1. Input single line with name of the method you are going to call. Supported names:
    * min-max
    * neyman-pirson
    * min-max-randomized
    * neyman-pirson-randomized
2. Next line should contain json-formatted string with params of method. All methods require 
'matrix' parameter, neyman-pirson and neyman-pirson-randomized require 'critical_value'
parameter too.
Examples of parameters input:
* For min-max and min-max-randomized:
```
{"matrix": [[1, 2], [2, 2], [5, 6]]}
```
* For neyman-pirson and neyman-pirson-randomized:
```
{"matrix": [[1, 2], [2, 2], [5, 6]], "critical_value": 2}
```

Output is a single json-formatted line in standard output stream.
Fields contained in outputted object differs for each method.
For each method output contains field:
    `matrix_loss` - 2-dimensional array of loss
* min-max fields:
    * `indexes_optimal` - list of indexes of solutions, corresponding to minimal loss
    * `loss` - value of minimal loss
* neyman-pirson fiels:
    * `indexes_optimal` - list of indexes of solutions, corresponding to minimal loss
    * `loss` - value of minimal loss
    * `indexes_excluded` - indexes of solutions excluded by critical_value by 1 state
    * `critical_value` - the same `critical_value` what has been received by this method as parameter
* min-max-randomized fields:
    * `indexes_convex_hull` - indexes of points what forms convex hull in order the should be connected
    * `solution_counts` - count of solutions found, could have one of the following values:
        * `NONE` - no solutions was found, SHOULD NO HAPPEN IN min-max-randomized
        * `SINGLE` - the loss matrix has single optimal solution, in this case vector X is not empty
        * `INFINITE` - the loss matrix has infinite number of optimal solutions, in this case vector `X` is empty
    * `X` - vector, representing optimal randomized solution. Empty or has the length equal to first 
    dimension of inputted matrix
    * `loss` - value of minimal loss
    Also have `indexes_optimal`, `indexes_intersection`, `intersection_ratio` fields but we do not need to use them.
* neyman-pirson-randomized fields:
    * `indexes_convex_hull` - indexes of points what forms convex hull in order the should be connected
    * `solution_counts` - count of solutions found, could have one of the following values:
        * `NONE` - no solutions was found, in this case `loss` is `null`
        * `SINGLE` - the loss matrix has single optimal solution, in this case vector X is not empty
        * `INFINITE` - the loss matrix has infinite number of optimal solutions, in this case vector `X` is empty
    * `X` - vector, representing optimal randomized solution. Empty or has the length equal to first 
    dimension of inputted matrix
    * `loss` - value of minimal loss. Could be float or `null`
    * `critical_value` - the same `critical_value` what has been received by this method as parameter
    Also have `indexes_optimal`, `indexes_intersection`, `intersection_ratio` fields but we do not need to use them.

Example of full sequence of interaction with api:
```
.\venv\Scripts\python api.py
min-max
{"matrix": [[1, 2], [2, 2], [5, 6]]}
```

Code to interact with api from C# (haven't tested):

string method = "min-max";
string params = "{\"matrix\": [[1, 2], [2, 2], [5, 6]]}"


ProcessStartInfo start = new ProcessStartInfo();
string curDir = Directory.GetCurrentDirectory();
DirectoryInfo directoryInfo = Directory.GetParent(curDir);
DirectoryInfo directoryInfo2 = Directory.GetParent(directoryInfo.FullName);
start.FileName = directoryInfo2.FullName + @"\analytics\venv\Scripts\python.exe";
string path = directoryInfo2.FullName + @"\analytics\api.py";

start.Arguments = path;
start.UseShellExecute = false;
start.RedirectStandardOutput = true;
start.RedirectStandardInput = true;
using (Process process = Process.Start(start))
{
    StreamWriter sq = process.StandardInput;
    sq.WriteLine(method);
    sq.WriteLine(params);
    using (StreamReader reader = process.StandardOutput)
        result = reader.ReadToEnd();
        # todo parse result as json
}