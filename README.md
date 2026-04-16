# shell-csharp

> A POSIX style shell implemented from scratch in C# and .NET 9. Built as a self directed systems programming exercise through the CodeCrafters "Build Your Own Shell" challenge. Actively in development.

<p>
  <img src="https://img.shields.io/badge/status-in%20progress-blue" alt="status">
  <img src="https://img.shields.io/badge/C%23-239120?logo=csharp&logoColor=white" alt="C#">
  <img src="https://img.shields.io/badge/.NET-9.0-512BD4?logo=dotnet&logoColor=white" alt=".NET 9">
  <img src="https://img.shields.io/badge/platform-POSIX-lightgrey" alt="POSIX">
</p>

---

## The Problem

A Unix shell is one of the most commonly used pieces of software on the planet, and most developers never stop to think about how it actually works. What happens between pressing Enter and seeing output? How does the shell find the right binary? How does it handle quoting, pipes, and redirection? The only way to really understand those answers is to build one.

## The Approach

I am implementing a POSIX style shell from scratch in C# on .NET 9. The CodeCrafters platform provides the test harness and the challenge specification, but every line of the implementation is my own. No tutorial walks through the solution. Each stage introduces a new requirement (a new builtin, a new parsing rule, a new I/O behavior), and I have to figure out how to meet it.

The goal is not just a working shell. It is internalizing how a shell interprets commands, manages processes, and handles the details that users take for granted. That knowledge transfers directly to backend work, where process management, parsing, and I/O are daily concerns.

---

## Current Status

This is an actively developed project. Progress is tracked below and updated as stages are completed.

### Completed

* Project scaffolding with .NET 9 and the CodeCrafters runner
* Basic REPL loop that reads input, dispatches on commands, and returns to the prompt
* Initial command recognition for a small set of inputs

### In progress

* Builtin commands: `exit`, `echo`, `type`, `pwd`, `cd`

### Planned

* Execution of external programs via `PATH` lookup
* Quoting rules: single quotes, double quotes, and backslash escapes
* I/O redirection: `>`, `>>`, `2>`, `<`
* Piping between commands with `|`
* Command history and line editing

---

## Key Decisions

### Why C# and .NET 9

Most shell challenge solutions are written in C, Go, or Rust. Choosing C# makes the exercise harder in some places (fewer reference implementations to compare against) and forces me to work closer to the platform than typical .NET application code requires. This is deliberate. I want to stretch my .NET knowledge into territory where I am using `Process`, `Environment`, and `System.IO` primitives the way they were designed to be used, not hidden behind ASP.NET abstractions.

### Why build instead of read

I could have read the source of an existing shell. That would have taught me less. Building something under test, where every stage has pass or fail feedback, forces me to understand each piece deeply enough to produce it rather than just recognize it. The wrong implementations fail tests. The right implementations pass. This is how I want to learn systems concepts.

### Why CodeCrafters

The platform provides the specification and the test harness, which removes the ambiguity of "am I done." Beyond that, I write all the code myself with no guided walkthroughs. It is the closest thing to a real engineering task that a self directed learning platform offers: clear requirements, verifiable completion, and full implementation freedom.

---

## Tech Stack

| Layer | Technology |
|-------|-----------|
| Language | C# 12 |
| Runtime | .NET 9 |
| Test harness | CodeCrafters test runner |
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
src/                Shell implementation (main entry point and command handling)
shell.sh            Wrapper script that builds and runs the shell
codecrafters.yml    Platform configuration for the test runner
.codecrafters/      Generated runtime files for the CodeCrafters harness
```

---

## What I Am Learning

Building a shell is teaching me concepts that rarely come up in typical backend CRUD work. Reading input character by character makes the difference between buffered and unbuffered I/O concrete in a way reading about it never did. Spawning external processes through `System.Diagnostics.Process` taught me how parent and child processes share file descriptors, how exit codes propagate, and why signal handling is more subtle than it looks. Even simple parsing for quoted strings turns out to involve state machines that are useful far beyond shells.

These are transferable lessons. Every backend system I work on in the future will have some version of these same primitives underneath, and I understand them better now than I did before this project.

---

## Roadmap

Short term goals beyond the CodeCrafters stages:

* Add a suite of my own unit tests independent of the CodeCrafters test runner
* Refactor the command dispatch into a clean interpreter pattern once all builtins are in
* Publish a short writeup on the parsing approach once redirection is implemented
* Benchmark startup and per command latency against bash and zsh

---

## About Me

I am Julio Quezada, a backend .NET developer from El Salvador with experience building production systems at national scale. I specialize in C#, ASP.NET Core, and PostgreSQL.

**Open to remote backend roles** across US, EU, and LATAM time zones.

[Portfolio](https://www.quezadajulio.com) · [LinkedIn](https://www.linkedin.com/in/jqdeveloper) · qjuliodev@gmail.com

---

## Acknowledgments

Challenge specification and test harness provided by [CodeCrafters](https://codecrafters.io/). Implementation is entirely my own.

---

## License

This repository is based on the CodeCrafters shell starter template. See the CodeCrafters documentation for licensing details. My implementation contributions are available under the MIT license.
