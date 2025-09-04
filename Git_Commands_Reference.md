# Git Commands Reference

## Basic Setup & Configuration

### Initial Setup
```bash
# Set your identity (global)
git config --global user.name "Your Name"
git config --global user.email "your.email@example.com"

# Set your identity (local to current repo)
git config user.name "Your Name"
git config user.email "your.email@example.com"

# Check your configuration
git config --list
git config user.name
git config user.email
```

### Repository Initialization
```bash
# Initialize a new repository
git init

# Clone an existing repository
git clone https://github.com/username/repo.git
git clone https://github.com/username/repo.git my-folder-name

# Check repository status
git status
```

## Working with Files

### Staging Changes
```bash
# Add specific files
git add filename.txt
git add file1.txt file2.txt

# Add all files in current directory
git add .

# Add all files in entire repository
git add -A

# Add only modified files (not new files)
git add -u

# Interactive staging (choose what to stage)
git add -i
```

### Committing Changes
```bash
# Commit staged changes
git commit -m "Your commit message"

# Commit all tracked files (skip staging)
git commit -am "Your commit message"

# Amend the last commit
git commit --amend -m "New commit message"

# Add changes to last commit
git add forgotten-file.txt
git commit --amend --no-edit
```

## Branching

### Creating and Switching Branches
```bash
# Create a new branch
git branch branch-name

# Switch to a branch
git checkout branch-name
git switch branch-name  # Newer command

# Create and switch to new branch
git checkout -b new-branch
git switch -c new-branch  # Newer command

# List all branches
git branch
git branch -a  # Include remote branches

# Delete a branch
git branch -d branch-name
git branch -D branch-name  # Force delete
```

### Merging
```bash
# Merge a branch into current branch
git merge branch-name

# Merge with no fast-forward (creates merge commit)
git merge --no-ff branch-name

# Abort a merge
git merge --abort
```

## Remote Repositories

### Working with Remotes
```bash
# Add a remote repository
git remote add origin https://github.com/username/repo.git

# List remotes
git remote -v

# Change remote URL
git remote set-url origin https://github.com/username/new-repo.git

# Remove a remote
git remote remove origin

# Rename a remote
git remote rename old-name new-name
```

### Pushing and Pulling
```bash
# Push to remote repository
git push origin main
git push -u origin main  # Set upstream and push

# Push all branches
git push --all origin

# Pull changes from remote
git pull origin main
git pull  # If upstream is set

# Fetch changes without merging
git fetch origin
git fetch --all
```

## Viewing History and Changes

### Log and History
```bash
# View commit history
git log
git log --oneline  # Compact view
git log --graph --oneline --all  # Visual graph
git log -p  # Show changes in each commit
git log --stat  # Show file statistics

# View specific commits
git show commit-hash
git show HEAD  # Latest commit
git show HEAD~1  # Previous commit
```

### Comparing Changes
```bash
# Compare working directory with staging area
git diff

# Compare staging area with last commit
git diff --staged
git diff --cached

# Compare two commits
git diff commit1 commit2

# Compare branches
git diff branch1..branch2
```

## Undoing Changes

### Reset Operations
```bash
# Unstage files (keep changes)
git reset HEAD filename.txt
git reset HEAD  # Unstage all

# Reset to last commit (keep changes in working directory)
git reset --soft HEAD~1

# Reset to last commit (discard changes)
git reset --hard HEAD~1

# Reset to specific commit
git reset --hard commit-hash
```

### Revert Operations
```bash
# Revert a commit (creates new commit)
git revert commit-hash

# Revert last commit
git revert HEAD
```

### Checkout for Undoing
```bash
# Discard changes to a file
git checkout -- filename.txt

# Restore a file from a specific commit
git checkout commit-hash -- filename.txt
```

## Stashing

### Save Work in Progress
```bash
# Stash current changes
git stash
git stash push -m "Work in progress"

# List stashes
git stash list

# Apply most recent stash
git stash apply
git stash pop  # Apply and remove from stash

# Apply specific stash
git stash apply stash@{2}

# Drop a stash
git stash drop stash@{0}

# Clear all stashes
git stash clear
```

## Tagging

### Working with Tags
```bash
# Create a lightweight tag
git tag v1.0

# Create an annotated tag
git tag -a v1.0 -m "Version 1.0"

# List tags
git tag
git tag -l "v1.*"  # List tags matching pattern

# Push tags to remote
git push origin v1.0
git push origin --tags  # Push all tags

# Delete a tag
git tag -d v1.0
git push origin --delete v1.0  # Delete from remote
```

## Advanced Commands

### Rebasing
```bash
# Rebase current branch onto another
git rebase main

# Interactive rebase (last 3 commits)
git rebase -i HEAD~3

# Abort rebase
git rebase --abort

# Continue rebase after resolving conflicts
git rebase --continue
```

### Cherry-picking
```bash
# Apply a specific commit to current branch
git cherry-pick commit-hash

# Cherry-pick multiple commits
git cherry-pick commit1 commit2 commit3

# Cherry-pick a range of commits
git cherry-pick start-commit..end-commit
```

### Submodules
```bash
# Add a submodule
git submodule add https://github.com/user/repo.git path/to/submodule

# Initialize and update submodules
git submodule init
git submodule update
git submodule update --init --recursive

# Update submodule to latest commit
git submodule update --remote
```

## Useful Aliases

### Setting Up Aliases
```bash
# Common aliases
git config --global alias.st status
git config --global alias.co checkout
git config --global alias.br branch
git config --global alias.ci commit
git config --global alias.unstage 'reset HEAD --'
git config --global alias.last 'log -1 HEAD'
git config --global alias.visual '!gitk'

# Advanced aliases
git config --global alias.lg "log --color --graph --pretty=format:'%Cred%h%Creset -%C(yellow)%d%Creset %s %Cgreen(%cr) %C(bold blue)<%an>%Creset' --abbrev-commit"
git config --global alias.undo 'reset HEAD~1 --mixed'
git config --global alias.amend 'commit -a --amend'
```

## Common Workflows

### Feature Branch Workflow
```bash
# Start new feature
git checkout -b feature/new-feature
# Make changes, commit
git add .
git commit -m "Add new feature"
# Push feature branch
git push -u origin feature/new-feature
# Create pull request on GitHub
# After approval, merge and cleanup
git checkout main
git pull origin main
git branch -d feature/new-feature
git push origin --delete feature/new-feature
```

### Hotfix Workflow
```bash
# Create hotfix branch from main
git checkout -b hotfix/urgent-fix
# Make fix, commit
git add .
git commit -m "Fix urgent issue"
# Push and create PR
git push -u origin hotfix/urgent-fix
```

## Troubleshooting

### Common Issues
```bash
# Fix merge conflicts
git status  # See conflicted files
# Edit files to resolve conflicts
git add resolved-file.txt
git commit

# Recover deleted files
git checkout HEAD -- deleted-file.txt

# Find when a line was introduced
git blame filename.txt
git log -p -S "search-term" filename.txt

# Clean up repository
git clean -fd  # Remove untracked files and directories
git gc  # Garbage collect
```

### Authentication Issues
```bash
# For HTTPS with Personal Access Token
git remote set-url origin https://username:token@github.com/username/repo.git

# For SSH (if configured)
git remote set-url origin git@github.com:username/repo.git

# Clear cached credentials
git config --global --unset credential.helper
```

## Quick Reference

### Daily Commands
```bash
git status                    # Check status
git add .                     # Stage all changes
git commit -m "message"       # Commit changes
git push                      # Push to remote
git pull                      # Pull latest changes
```

### Emergency Commands
```bash
git stash                     # Save work in progress
git checkout -- filename      # Discard file changes
git reset --hard HEAD         # Discard all changes
git log --oneline             # Quick commit history
```

---

**Note:** Replace `main` with your default branch name if different (e.g., `master`). Always be careful with destructive commands like `git reset --hard` and `git push --force`.
