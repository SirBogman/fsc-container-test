# fsc-container-test

I'm trying to add F# to a [Code Golf](https://code-golf.io) website. To do this, I need to create a container that can be used to run a simple F# program. The time limit for building and running a solution on that website is seven seconds. I'm aiming for being able to compile and run a trivial program that outputs its command line arguments in about 1 second, because that's what I can achieve with C# and Java, or at most two.

Here are three attempts to build a container that I can use to compile a code golf "script", which must compile and run in less than seven seconds.

## 1. dotnet-build

It takes about 7 seconds to build the script. This is too long, because the limit is 7 seconds.

I had this problem with C# too. I solved it by invoking the compiler directly, which takes about 1 second.

## 2. fsc

It takes about 3.5 seconds to compile with `fsc` directly which is at least less than the 7 second limit.

Running the compiled script with `dotnet` doesn't work:

```Unhandled exception. System.MethodAccessException: Entry point must have a return type of void, integer, or unsigned integer.```

Running it with a runner app doesn't work either:
```About to run.
Unhandled exception. System.Reflection.TargetInvocationException: Exception has been thrown by the target of an invocation.
 ---> System.MissingMethodException: Method not found: 'Void Microsoft.FSharp.Core.PrintfFormat`5..ctor(System.String)'.
   --- End of inner exception stack trace ---
   at System.RuntimeMethodHandle.InvokeMethod(Object target, Object[] arguments, Signature sig, Boolean constructor, Boolean wrapExceptions)
   at System.Reflection.RuntimeMethodInfo.Invoke(Object obj, BindingFlags invokeAttr, Binder binder, Object[] parameters, CultureInfo culture)
   at System.Reflection.MethodBase.Invoke(Object obj, Object[] parameters)
   at Runner.runCode(Assembly assembly, String[] args) in /runner_source/Runner.fs:line 13
   at Runner.main(String[] args) in /runner_source/Runner.fs:line 23
Command terminated by signal 6
```

## 3. wrapper

Takes about 6 seconds to run a code golf solution.

I thought ready to run might help, but I wasn't able to get it to work.

I can't use the arguments `--runtime linux-musl-x64 -p:PublishReadyToRun=true` for `dotnet publish`, because I get the following runtime error when it's trying to compile the script.

```
unknown (1,1)-(1,1) parse error Could not load file or assembly 'System.Private.CoreLib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e'.
```
