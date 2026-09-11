---
name: dependabot-fixer
description: 'Analyze and fix GitHub Dependabot security alerts and dependency vulnerabilities. Use when reviewing Dependabot alerts, updating vulnerable npm, NuGet, or other dependencies, resolving dependency and lockfile conflicts, validating security fixes, or preparing a pull request for Dependabot remediation.'
argument-hint: '[optional alert number, package name, severity, or repository scope]'
user-invocable: true
---

# Dependabot Fixer

Analyze and remediate GitHub Dependabot issues with the smallest version change that resolves the vulnerability while preserving application behavior.

## Safety Rules

- Never expose tokens, secrets, lockfile credentials, or private repository data in chat, logs, or a pull request.
- Do not dismiss, suppress, or downgrade an alert without explicit user approval and a documented reason.
- Do not merge, approve, force-push, or deploy a change unless the user explicitly requests it.
- Treat generated lockfiles as source-controlled artifacts: review their diff for unexpected package, registry, or integrity changes.
- Keep unrelated dependency upgrades and formatting changes out of the fix.

## Procedure

1. Identify the target repository and requested scope. Confirm the current branch and working tree with `git status --short --branch` and preserve unrelated user changes.
2. Check tool availability with `gh auth status`, `gh repo view --json nameWithOwner`, and the repository's package manifests. If GitHub CLI authentication or repository access is unavailable, report the blocker and continue only with local dependency analysis.
3. Inventory open Dependabot alerts using the GitHub CLI/API. Prefer `gh api --paginate repos/{owner}/{repo}/dependabot/alerts` and record each alert's number, severity, package, ecosystem, vulnerable range, patched version, manifest path, and dependency relationship. When an alert number or package is supplied, narrow the inventory to it.
4. Inspect the affected manifest and lockfile, then trace the dependency path. For npm use `npm ls <package> --all` and the repository's package manager; for .NET use `dotnet list package --vulnerable --include-transitive`; use the ecosystem's native inspection command for other manifests.
5. Choose the minimum viable remediation:
   - Upgrade the direct dependency to the first compatible patched release when possible.
   - For a transitive dependency, upgrade its direct parent or add an override/resolution only when that matches the repository's existing conventions.
   - If the patched release requires a breaking major upgrade, inspect changelogs and call sites before editing and clearly flag the migration risk.
6. Update the manifest and regenerate only the relevant lockfile using the repository's package manager. Do not hand-edit integrity, dependency graph, or resolved-version entries unless the ecosystem tool cannot regenerate them.
7. Review the diff for scope, unexpected transitive changes, registry changes, scripts, and license metadata. Confirm the vulnerable version is gone with the ecosystem audit command and, when available, `gh api repos/{owner}/{repo}/dependabot/alerts/{alert_number}`.
8. Run focused validation first, then the repository's required checks. For this repository, use `npm ci` or the existing lockfile-compatible install, `npm run lint`, and the relevant build/test commands; for backend changes also run `dotnet build backend/api/LCPApi/LCPApi.csproj`.
9. Recheck the alert after the fix. A GitHub alert may remain open until Dependabot rescans the default branch, so distinguish “fixed in branch” from “closed by GitHub.”
10. Summarize the alert, root cause, files changed, patched version, validation results, remaining alerts, and any compatibility risk. If requested, create a branch and pull request with `gh pr create`; include the security impact, testing, and a concise scope statement. Leave merge and deployment to the user.

## GitHub Commands

Use placeholders rather than literal credentials:

```powershell
$repo = gh repo view --json nameWithOwner --jq .nameWithOwner
gh api --paginate "repos/$repo/dependabot/alerts?state=open&per_page=100"
gh api "repos/$repo/dependabot/alerts/{alert_number}"
```

If the API response is unavailable, inspect the repository's Dependabot pull requests with `gh pr list --author app/dependabot --state all` and report that alert status could not be verified directly.

## Completion Criteria

A remediation is complete only when the affected dependency is upgraded to a patched version, the manifest and lockfile are consistent, focused checks pass, the diff is limited to the intended fix, and the final report distinguishes local results from GitHub's rescan status.
