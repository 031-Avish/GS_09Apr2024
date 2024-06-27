#Compilation
# The program is converted into byte code. Byte code is a fixed set of instructions that represent arithmetic, comparison, memory operations, etc. It can run on any operating system and hardware. The byte code instructions are created in the .pyc file.
#Interpreter
#The next step involves converting the byte code (.pyc file) into machine code. This step is necessary as the computer can understand only machine code (binary code). Python Virtual Machine (PVM) first understands the operating system and processor in the computer and then converts it into machine code. Further, these machine code instructions are executed by processor and the results are displayed.

######### {python -m py_compile ExecutionOfPython.py }

#  command is used to compile the python file. The compiled file is saved as ExecutionOfPython.pyc. The .pyc file is created in the same directory as the .py file. The .pyc file is a byte code file that is used by the interpreter to convert it into machine code.

######## {python ExecutionOfPython.cpython-312.pyc} to run the compiled file. The output is displayed on the screen.

#However, the interpreter inside the PVM translates the program line by line thereby consuming a lot of time. To overcome this, a compiler known as Just In Time (JIT) is added to PVM. JIT compiler improves the execution speed of the Python program. This compiler is not used in all Python environments like CPython which is standard Python software.

# example code 

a=20
b=30
c=a+b
print(c)