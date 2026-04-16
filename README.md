# shell-csharp

> A POSIX style shell implemented from scratch in C# and .NET 9. Interactive REPL, builtin commands, external process execution, and shell parsing. Actively in development.

<p>
  <img src="https://img.shields.io/badge/status-in%20progress-blue" alt="status">
  <img src="https://img.shields.io/badge/C%23-239120?logo=csharp&logoColor=white" alt="C#">
  <img src="https://img.shields.io/badge/.NET-9.0-512BD4?logo=dotnet&logoColor=white" alt=".NET 9">
  <img src="https://img.shields.io/badge/platform-POSIX-lightgrey" alt="POSIX">
</p>

---

## The Problem

A Unix shell is one of the most commonly used pieces of software in the world, and most developers never stop to think about how it actually works. What happens between pressing Enter and seeing output? How does the shell find the right binary on the system? How does quoting work when strings contain spaces, escapes, or nested quotes? What is the precise sequence of system calls that spawns a child process, inherits its file descriptors, and reports its exit code? The only way to understand those answers with any depth is to build a shell.

## The Approach

A POSIX style shell in C# on .NET 9, built from scratch. The scope includes a read eval print loop, a set of builtin commands, external program execution via `PATH` lookup, quoting and escape rules, and I/O redirection. Each of those subsystems is a small exercise in parsing, process management, or I/O that has been written about for decades in operating systems textbooks. Implementing them in modern C# produces a working program and a much deeper understanding of the platform the shell runs on.

---

## Current Status

This is an actively developed project. The list below is updated as stages are completed.

### Completed

* Interactive REPL loop that reads input, dispatches on commands, and returns to the prompt
* Initial command recognition for a small set of inputs
* Project scaffolding on .NET 9 with a shell runner script

### In progress

* Builtin commands: `exit`, `echo`, `type`, `pwd`, `cd`

### Planned

* External program execution via `PATH` lookup
* Quoting rules: single quotes, double quotes, backslash escapes
* I/O redirection: `>`, `>>`, `2>`, `<`
* Command piping with `|`
* Command history and line editing

---

## Key Decisions

### Why C# and .NET 9

Most shell implementations are written in C, Go, or Rust. Choosing C# for this is deliberate. It forces me to work closer to the platform than typical .NET application code requires, using `System.Diagnostics.Process`, `Environment`, and `System.IO` primitives the way they were designed to be used rather than hidden behind ASP.NET abstractions. It is a chance to stretch my .NET knowledge into systems level territory that most web focused backend developers never touch.

### Why build instead of read

I could have read the source of an existing shell. That would have taught me less. Building something under test, where each feature has pass or fail feedback, forces a level of understanding that reading never produces. Wrong implementations fail tests. Right ones pass. At the end of each stage I know exactly which corner cases I handled and which I did not, because the test suite told me.

### Why a single process, synchronous design first

The first working version keeps everything in a single process with synchronous command dispatch. Adding asynchronous I/O or multi process piping from day one would have buried the core parser and REPL logic under concurrency concerns. The plan is to finish the synchronous version across all builtins and redirection, then introduce pipes and concurrency in a second pass when the foundation is solid. This is the same principle I apply in backend service design: get the data flow correct first, then optimize.

---

## Tech Stack

| Layer | Technology |
|-------|-----------|
| Language | C# 12 |
| Runtime | .NET 9 |
| Target platform | POSIX (Linux, macOS, WSL) |

---

## Running Locally

You need .NET 9 installed.

```bash
git clone https://github.com/Alejandroq12/shell-csharp.git
cd shell-csharp
./shell.sh
```

The shell starts an interactive prompt. Type commands as you would in any shell. Press `Ctrl+D` or type `exit` to leave.

---

## Project Structure

```
src/            Shell implementation
shell.sh        Wrapper script that builds and runs the shell
```

---

## What I Am Learning

Building a shell surfaces concepts that rarely come up in typical backend work. Reading input character by character makes the difference between buffered and unbuffered I/O concrete in a way reading about it never did. Spawning external processes through `System.Diagnostics.Process` exposes how parent and child processes share file descriptors, how exit codes propagate, and why signal handling is subtler than it appears. Even parsing quoted strings turns out to involve small state machines that show up in far more places than shells.

These are transferable lessons. Every backend system I work on in the future will have some version of these same primitives underneath, and I understand them better now than I did before.

---

## Roadmap

Beyond the core feature set:

* A suite of unit tests independent of the external test harness
* Refactor the command dispatch into a clean interpreter pattern once all builtins are in
* A short writeup on the parsing approach once redirection is implemented
* Benchmark startup and per command latency against bash and zsh

---

## About Me

I am Julio Quezada, a backend .NET developer from El Salvador with experience building production systems at national scale. I specialize in C#, ASP.NET Core, and PostgreSQL.

**Open to remote backend roles** across US, EU, and LATAM time zones.

[Portfolio](https://www.quezadajulio.com) · [LinkedIn](https://www.linkedin.com/in/jqdeveloper) · qjuliodev@gmail.com

---

## License

The scaffolding for this project is based on a starter template from [CodeCrafters](https://codecrafters.io/). All implementation code is my own and released under the MIT license.
