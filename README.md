# WinVOIE

Logiciel de supervision de machine de travaux de voie (VB.NET, Windows Forms, .NET Framework 4.8).
Projet **de démonstration** : entreprise fictive FERRODEMO, aucun code client.

> **Avertissement** : la procédure ci-dessous décrit des pratiques techniques recommandées par LaPolaris. Elle ne constitue pas un avis juridique et ne garantit pas la conformité à une réglementation, Cyber Resilience Act compris. Les mentions réglementaires et les informations sur les offres GitHub sont indicatives à la date de rédaction et peuvent évoluer : à vérifier auprès des sources officielles avant toute décision.

## Compiler

Prérequis : Visual Studio 2022 17.14 (ou MSBuild de Visual Studio), .NET Framework 4.8.

```powershell
msbuild WinVOIE.sln -t:restore -p:RestorePackagesConfig=true
msbuild WinVOIE.sln -p:Configuration=Release -m

# Tests unitaires (xUnit, projet tests\WinVOIE.Tests)
vstest.console tests\WinVOIE.Tests\bin\Release\WinVOIE.Tests.dll
```

`dotnet build` ne convient pas : il ne restaure pas `packages.config` et échoue sur les `.resx` contenant des images.
Le projet d'installation `Setup/Setup.vdproj` ne se compile qu'avec Visual Studio et l'extension « Installer Projects ».

## Installer sur un poste

Les accès maintenance (profils `SUPERVISEUR` et `SAV`) exigent le fichier `C:\WVOIE\PARAMETRES\acces.par`,
qui ne contient que des empreintes de mots de passe. Le créer en administrateur, une fois par profil :

```powershell
powershell -File outils\creer-acces.ps1 -Profil SUPERVISEUR
powershell -File outils\creer-acces.ps1 -Profil SAV
```

Aucun mot de passe n'est stocké dans le dépôt ni dans le programme.

## Composants tiers hors NuGet

Invisibles pour Dependabot et pour le SBOM CycloneDX : à déclarer à la main.

| Fichier | Version | Origine | Licence |
|---|---|---|---|
| `WinVOIE/dll/TwinCAT.Ads.dll` | 4.3.30 | DLL factice de démonstration (API Beckhoff TwinCAT ADS) | — |
| `WinVOIE/dll/Fde.Vmp60.Network.dll` | 1.2.0 | DLL factice de démonstration | — |

---

# Procédure : mettre en place un nouveau dépôt

À suivre **à chaque création de dépôt**. Un dépôt créé sans ruleset, sans CODEOWNERS et sans équipes échappe à toutes les règles : chaque nouveau dépôt reçoit la même configuration que le précédent.

L'ordre compte : chaque étape rend la précédente opposable.

| # | Étape | Où |
|---|---|---|
| 0 | Poste du développeur | une fois par poste |
| 1 | Organisation et accès | une fois, puis à vérifier |
| 2 | Création du dépôt et droits | GitHub |
| 3 | Fichiers d'hygiène | premier commit |
| 4 | Réglages des pull requests | Settings, General |
| 5 | Ruleset `protection-main` | Settings, Rules |
| 6 | Fichiers de collaboration (`.github/`) | par pull request |
| 7 | Labels et jalons | Issues |
| 8 | Intégration continue | par pull request |
| 9 | Sécurité | Settings, Advanced Security + pull request |
| 10 | Version livrée : tag, release, SBOM, signature | à chaque livraison |

---

## 0. Poste du développeur

Une fois par poste, avant le premier dépôt :

```powershell
git config --global user.name "Prénom Nom"
git config --global user.email "prenom.nom@entreprise.fr"     # ou l'adresse noreply de GitHub (Settings, Emails)
git config --global core.editor "code --wait"                 # sinon Git ouvre Vim
git config --global init.defaultBranch main
git config --global credential.helper manager                 # Git Credential Manager, connexion par navigateur
git config --global fetch.prune true
git config --global core.quotepath false                      # accents lisibles dans git status
```

- [ ] Authentification par **Git Credential Manager**, clé SSH `ed25519` ou jeton **fine-grained** (90 jours maximum, droits minimum). Jamais de mot de passe.
- [ ] Plusieurs comptes GitHub sur le poste : identité **par dépôt** (`git config user.email …` sans `--global`, `git config credential.username …`).
- [ ] Visual Studio 2022 en **17.14.x** (seule ligne encore corrigée).
- [ ] Politique Copilot et « Explain error » tranchée avec l'entreprise : le code est envoyé au service.

## 1. Organisation et accès

À vérifier à chaque nouveau dépôt :

- [ ] Le dépôt est dans l'**organisation**, jamais sur un compte personnel.
- [ ] Offre de l'organisation connue (Settings de l'organisation, Billing) : en offre **Free**, un dépôt **privé** n'a ni ruleset effectif, ni relecteurs obligatoires, ni CODEOWNERS. Il faut **Team** au minimum.
- [ ] Authentification à deux facteurs **exigée** pour l'organisation.
- [ ] Droit de base des membres : **Read**.
- [ ] Équipes en place, au moins **deux personnes** dans chaque équipe de relecteurs :

| Équipe | Rôle sur le dépôt | Usage |
|---|---|---|
| `developpeurs` | Write | proposer, relire le code applicatif |
| `responsables` | Maintain | relire `.github/`, workflows, `SECURITY.md`, DLL de fournisseurs |
| (une personne identifiée) | Admin | réglages et protections, pas forcément celle qui fusionne |

- [ ] Réglages de sécurité définis **au niveau de l'organisation** (Settings de l'organisation, Advanced Security) pour que les nouveaux dépôts en héritent. Sinon, tout se réactive dépôt par dépôt (étape 9).
- [ ] Revue des accès à chaque arrivée, départ ou changement de poste, et au moins une fois par an.

## 2. Création du dépôt et droits

- [ ] Dépôt créé dans l'organisation, **privé**. Pour publier un code existant : dépôt **vide** (sans README, `.gitignore` ni licence, sinon le premier push est refusé).
- [ ] **Équipes ajoutées à ce dépôt** : Settings, Collaborators and teams. Un nouveau dépôt ne donne rien aux équipes : sans cet ajout, un développeur ne peut ni pousser, ni faire compter son approbation.
- [ ] Code existant encore hors Git (partage réseau) : `git init`, fichiers de l'étape 3, premier commit, puis :

```powershell
git remote add origin https://github.com/<organisation>/<depot>.git
git push -u origin --all
git push origin --tags          # les tags ne partent pas avec les branches
```

- [ ] Dépôt transféré depuis un compte personnel : `git remote set-url origin …` sur **chaque** poste.

Point de vérification : chaque membre peut cloner **et pousser une branche**.

## 3. Fichiers d'hygiène (premier commit)

| Fichier | Contenu attendu |
|---|---|
| `.editorconfig` | **en premier**, à la racine. UTF-8 (`utf-8-bom` acceptable pour du VB), espaces, CRLF, `indent_size = 2` pour `*.{yml,yaml}`. Le fichier lui-même enregistré en UTF-8 |
| `.gitignore` | modèle `VisualStudio.gitignore` de `github/gitignore`, plus `coveragereport/`, `*.pfx`, `*.snk`. Écrire `packages/*` et non `packages/` |
| `.gitattributes` | `* text=auto`, `*.sln text eol=crlf`, `*.sh text eol=lf`, binaires (`*.dll`, `*.exe`, `*.png`…) en `binary` |
| `README.md` | à quoi sert le projet, comment le compiler, comment le livrer, **liste des DLL hors NuGet** (nom, version, origine, licence) |
| `SECURITY.md` | versions prises en charge, canal de signalement, délais. **Adresse et délais validés par la direction** (voir étape 9) |
| `CHANGELOG.md` | initialisé, ou repris s'il existe |

Nettoyage d'un code existant :

```powershell
# Retirer du suivi tout ce que le .gitignore exclut désormais (bin/, obj/ sont dans chaque projet)
git rm -r --cached .
git add .
git status                              # plus aucun bin/, obj/, packages/
git commit -m "chore: retire les fichiers générés du suivi"

git ls-files "*.pfx" "*.snk"            # clés et certificats suivis
git grep -n "<<<<<<<\|>>>>>>>"          # marqueurs de conflit oubliés
git grep -n -i "motdepasse\|password\|mdp"   # mots de passe en dur : aucun outil ne les voit
```

- [ ] Fichiers parasites retirés : brouillons personnels, sorties de commande enregistrées par erreur (piège du `s` dans `less` sous Git Bash), installateurs compilés.
- [ ] Une clé, un certificat ou un mot de passe déjà présent dans l'historique est **compromis** : le remplacer, le retirer du suivi ne suffit pas.
- [ ] DLL de fournisseurs dans un dossier du dépôt (`lib/`), référencées par chemin **relatif**. Jamais de chemin absolu vers le poste d'un développeur.
- [ ] Ajout de `.gitattributes` sur un dépôt existant : `git add --renormalize .` dans un commit dédié.

Point de vérification : `git status` est propre après une compilation.

## 4. Réglages des pull requests

Settings, General, rubrique Pull Requests :

- [ ] **Allow merge commits** : coché, seul mode autorisé (traçabilité : le commit de fusion porte le numéro de la PR)
- [ ] **Allow squash merging** : décoché
- [ ] **Allow rebase merging** : décoché
- [ ] **Always suggest updating pull request branches** : coché
- [ ] **Automatically delete head branches** : coché

## 5. Ruleset `protection-main`

Settings, Rules, Rulesets, New branch ruleset.

- Nom : `protection-main` ; Enforcement status : **Active**
- Cibles : branche par défaut **et** `release/**` (Add target, Include by pattern)
- **Bypass list : vide**, administrateurs et propriétaire compris

| Réglage | Valeur |
|---|---|
| Require a pull request before merging | activé |
| Required approvals | 1 |
| Dismiss stale pull request approvals when new commits are pushed | activé |
| Require review from Code Owners | activé (sans lui, CODEOWNERS ne bloque rien) |
| Require conversation resolution before merging | activé |
| Allowed merge methods | Merge |
| Require status checks to pass | activé **après** l'étape 8, contrôle `build` |
| Require branches to be up to date before merging | activé avec les status checks |
| Require linear history | **désactivé** (incompatible avec les commits de fusion) |
| Block force pushes | activé |
| Restrict deletions | activé |

Point de vérification : un `git push` direct sur `main` est refusé (`GH013`), **y compris pour le propriétaire**.

Commit fait sur `main` par erreur :

```powershell
git switch -c chore/ma-branche
git branch -f main origin/main
git push -u origin chore/ma-branche
```

## 6. Fichiers de collaboration (`.github/`)

Ces fichiers ne s'appliquent **qu'une fois présents sur `main`** : ils s'installent par pull request, et la PR qui les installe n'en profite pas. Ils se commitent en `docs:` ou `chore:`, **jamais en `fix:`**.

| Fichier | Contenu |
|---|---|
| `.github/CODEOWNERS` | `*` → `developpeurs` ; code source → `developpeurs` ; `/.github/`, `/.github/workflows/`, `/SECURITY.md`, dossier des DLL de fournisseurs → `responsables`. La dernière règle correspondante l'emporte |
| `.github/pull_request_template.md` | description, `Closes #`, nature (dont « Tests seuls » et « Outillage, intégration continue »), impact sur le comportement, vérifications, points d'attention |
| `.github/ISSUE_TEMPLATE/anomalie.md` | observé, attendu, reproduction, version, machine ou client, criticité ; `labels: anomalie` |
| `.github/ISSUE_TEMPLATE/evolution.md` | même principe ; `labels: evolution` |

- [ ] **Pas de modèle d'issue « sécurité »** : une issue est publique. Le signalement passe par `SECURITY.md`.
- [ ] CODEOWNERS valide : pas de bandeau « This CODEOWNERS file contains errors », et :

```powershell
gh api repos/<organisation>/<depot>/codeowners/errors     # attendu : {"errors":[]}
```

Une équipe de CODEOWNERS doit **exister**, être **visible** (pas secrète) et avoir l'accès **Write** au dépôt.

Point de vérification : une PR qui touche `.github/` demande automatiquement la revue des `responsables`, et ne peut pas être fusionnée sans eux.

## 7. Labels et jalons

Supprimer les labels par défaut en doublon (`bug`, `enhancement`, `documentation`…). Une couleur par famille.

| Famille | Labels |
|---|---|
| Nature | `securite`, `anomalie`, `evolution`, `documentation` |
| Priorité | `p1-bloquant`, `p2-important`, `p3-normal` |
| Outillage | `dependances`, `ci`. À créer **avant** de fusionner `dependabot.yml` |
| Portée (si besoin) | `module-…` |

- [ ] `securite` obligatoire sur tout correctif de sécurité : c'est lui qui permet d'extraire les vulnérabilités traitées dans une version.
- [ ] Un jalon par version (`v2.5`) : il donne la liste de ce que la version contient.

## 8. Intégration continue

Fichier `.github/workflows/ci.yml`, ajouté par pull request.

- [ ] Déclencheurs : `push` et `pull_request` sur `main` **et `release/**`**
- [ ] `permissions: contents: read` au niveau du workflow ; un job qui écrit le déclare lui-même
- [ ] Actions officielles, versions épinglées, vérifiées sur la Marketplace (Dependabot les surveille ensuite)
- [ ] Runner : `windows-latest` pour WPF, Windows Forms, .NET Framework ; `ubuntu-latest` pour le reste (deux fois moins cher). Épinglage (`windows-2025`) à trancher dans la charte
- [ ] Résultats de tests publiés en artefact avec `if: always()`
- [ ] Binaires en artefact nommés avec `${{ github.sha }}`
- [ ] Première exécution **réussie sur `main`**, puis contrôle ajouté au ruleset

**Projet SDK (.NET 8+)** : `actions/setup-dotnet`, `dotnet restore`, `dotnet build`, `dotnet test`, et un `global.json` pour fixer le SDK.

**Projet .NET Framework 4.8 (`packages.config`)** :

```yaml
name: CI

on:
  push:
    branches: [ main, 'release/**' ]
  pull_request:
    branches: [ main, 'release/**' ]

permissions:
  contents: read

jobs:
  build:
    runs-on: windows-latest
    steps:
      - uses: actions/checkout@v7
      - uses: microsoft/setup-msbuild@v3      # v3 : Node 24 (la v2 affiche « Node.js 20 is deprecated »)

      # dotnet restore ne lit pas packages.config
      - name: Restaurer les paquets
        run: msbuild MaSolution.sln -t:restore -p:RestorePackagesConfig=true

      - name: Compiler
        run: msbuild MaSolution.sln -p:Configuration=Release -m

      - name: Exécuter les tests
        shell: pwsh
        run: |
          $vswhere = "${env:ProgramFiles(x86)}\Microsoft Visual Studio\Installer\vswhere.exe"
          $vstest = & $vswhere -latest -products * -find "Common7\IDE\CommonExtensions\Microsoft\TestWindow\vstest.console.exe" | Select-Object -First 1
          & $vstest tests\MonProjet.Tests\bin\Release\MonProjet.Tests.dll "/logger:trx;LogFileName=resultats.trx" /ResultsDirectory:TestResults
          exit $LASTEXITCODE

      - uses: actions/upload-artifact@v7
        if: always()
        with:
          name: resultats-tests
          path: TestResults
          retention-days: 30

      - uses: actions/upload-artifact@v7
        with:
          name: monprojet-${{ github.sha }}
          path: src/MonProjet/bin/Release
          retention-days: 90
```

À retenir :

- restauration : `msbuild -t:restore -p:RestorePackagesConfig=true` plutôt que `nuget restore` : un outil de moins à installer et à épingler, et NuGet Audit s'exécute pendant la restauration ;
- les tests vivent dans un **projet séparé** de la solution (`tests/MonProjet.Tests`), qui référence le projet testé ; `InternalsVisibleTo` si le code testé est `Friend`/`internal` ;
- un workflow par contrôle (`build`, `tests`…) est plus lisible et s'exige séparément, au prix d'une compilation par workflow ;
- le contrôle à exiger est **l'identifiant du job** (`build`), pas le nom du workflow ; renommer un job casse la règle ;
- n'exiger qu'un contrôle **produit par le workflow de `main`**, sinon toutes les PR restent sur « Expected — Waiting for status to be reported » ;
- un job sauté par `needs:` compte comme réussi : exiger aussi le job amont ;
- `dotnet test` sur un projet à l'ancien format n'exécute rien et renvoie 0 : utiliser `vstest.console` ;
- un `.vdproj` ne se compile pas avec MSBuild : installateur manuel ou migration vers WiX, décision de charte ;
- un artefact expire (90 jours) : ce n'est pas un archivage. Les versions livrées vont dans une release (étape 10).

Point de vérification : une PR approuvée dont le build est rouge ne peut pas être fusionnée.

## 9. Sécurité

### Licences : à vérifier avant de planifier

| Fonction | Dépôt public | Dépôt privé |
|---|---|---|
| Graphe de dépendances, Dependabot alerts et security updates | gratuit | gratuit |
| CodeQL, revue des dépendances (`dependency-review-action`) | gratuit | **GitHub Code Security** |
| Secret scanning, push protection | gratuit | **GitHub Secret Protection** |
| Signalement privé de vulnérabilité | gratuit | **n'existe pas** : le canal est l'adresse de `SECURITY.md` |
| Attestation de provenance | gratuit | **GitHub Enterprise Cloud** |
| Outils lancés dans un workflow (NuGet Audit, analyseurs, Gitleaks, CycloneDX) | gratuit | gratuit |

### Réglages (Settings, Advanced Security)

Chaque nouveau dépôt repart de zéro, sauf réglages définis au niveau de l'organisation.

- [ ] Dependency graph
- [ ] Automatic dependency submission (indispensable en format SDK pour voir les transitives ; inutile avec `packages.config`)
- [ ] Dependabot alerts
- [ ] **Dependabot malware alerts** (désactivé par défaut)
- [ ] Dependabot security updates
- [ ] Secret Protection, puis **Push protection** (s'active à part)
- [ ] Private vulnerability reporting (dépôt public seulement)

### `.github/dependabot.yml`

Par pull request, labels `dependances` et `ci` créés avant :

```yaml
version: 2
updates:
  - package-ecosystem: "nuget"
    directory: "/"                  # dossier du .sln ou du packages.config
    schedule:
      interval: "weekly"
      day: "monday"
      time: "07:00"
      timezone: "Europe/Paris"
    open-pull-requests-limit: 5
    labels: [ "dependances" ]
    commit-message:
      prefix: "build"
      include: "scope"
    groups:
      dependances-mineures:
        update-types: [ "minor", "patch" ]

  - package-ecosystem: "github-actions"
    directory: "/"
    schedule:
      interval: "monthly"
    labels: [ "dependances", "ci" ]
```

### Contrôles dans le pipeline

- [ ] **NuGet Audit** à la restauration : `NuGetAuditMode=all` dans un `Directory.Build.props` (projets SDK). Avertissements `NU1901` à `NU1904`. Le rendre bloquant (`WarningsAsErrors` `NU1903;NU1904`) seulement quand l'équipe sait qualifier une alerte. Sur `packages.config`, il fonctionne si la restauration passe par MSBuild.
- [ ] **Analyseurs .NET** en `Recommended`, sans `TreatWarningsAsErrors` au départ. Sur un projet à l'ancien format, `EnableNETAnalyzers` ne fait rien : ajouter au `.vbproj`/`.csproj`

```xml
<GlobalAnalyzerConfigFiles Include="..\packages\Microsoft.CodeAnalysis.NetAnalyzers.9.0.0\buildTransitive\config\analysislevel_9_recommended.globalconfig" />
```

- [ ] **Détection de secrets** : Gitleaks lancé directement (l'action exige une licence pour un dépôt d'organisation), version épinglée, `fetch-depth: 0`, règles maison dans `.gitleaks.toml` **enregistré en UTF-8 sans BOM**.
- [ ] **Revue des dépendances** sur les PR (`actions/dependency-review-action`, `fail-on-severity: high`), ajoutée aux contrôles requis une fois sur `main`. Licence requise en privé.
- [ ] **CodeQL** si licence : C# uniquement. **CodeQL n'analyse pas le VB.NET.**

### Ce qu'aucun outil ne voit

- Un mot de passe comparé en dur (`If saisie = "…" Then`) ou une clé maison : recherche manuelle (`git grep`), sortie du code, mot de passe changé.
- Les DLL hors NuGet : inventaire tenu à la main (README, SBOM).
- Les branches `release/x.y` : Dependabot ne surveille que la branche par défaut. Audit à chaque correctif.

### Traitement des alertes

- [ ] Revue hebdomadaire des alertes, à jour fixe.
- [ ] Une issue `securite` par alerte retenue, avec la **décision écrite**, y compris quand on ne corrige pas.
- [ ] Une PR de Dependabot ou d'Autofix se relit comme les autres : elle peut changer un comportement ou épingler une transitive inutilement.

### `SECURITY.md` et `security.txt`

- [ ] `SECURITY.md` à la racine : versions prises en charge, « n'ouvrez pas d'issue publique », adresse, délais (accusé de réception, qualification), divulgation coordonnée, article 14 du CRA (alerte ENISA sous 24 h). **Délais et adresse validés par la direction.**
- [ ] `/.well-known/security.txt` sur le site de l'entreprise (RFC 9116), champ `Expires` à jour.

Point de vérification : l'onglet **Security and quality** contient des alertes **qualifiées**, pas seulement remontées.

## 10. À chaque version livrée

**Un tag, une release, un binaire, un SBOM, une signature, une attestation : tous issus du même tag.**

- [ ] Tag `vMAJEUR.MINEUR.CORRECTIF` (annoté). Incrément : `fix` → correctif, `feat` → mineur, rupture → majeur.
- [ ] Version de l'assembly **alignée sur le tag**.
- [ ] Branche `release/x.y` créée depuis le commit livré si la version doit être maintenue.
- [ ] Binaire **construit par le pipeline depuis le tag**, jamais sur un poste.
- [ ] SBOM CycloneDX **sur le projet du produit**, pas sur la solution, avec nom et version :

```powershell
git switch --detach vX.Y.Z
dotnet tool install --global CycloneDX
dotnet CycloneDX src/MonProjet/MonProjet.csproj -o ./sbom -F Json -sn MonProjet -sv X.Y.Z
git switch main
```

  Fichier renommé `<Produit>-<version>.cdx.json`. **DLL hors NuGet ajoutées à la main.**
- [ ] Signature de l'`.exe` et des `.dll` produites par l'équipe (jamais les DLL de fournisseurs), **avec horodatage** :

```powershell
signtool sign /fd SHA256 /sha1 <empreinte> /tr http://timestamp.digicert.com /td SHA256 MonApp.exe MonApp.dll
signtool verify /pa /v MonApp.exe
```

- [ ] Attestation de provenance (`actions/attest-build-provenance`) déclenchée **sur le tag**, jamais sur une PR.
- [ ] Release GitHub créée sur le tag, avec binaire et SBOM attachés, **sans** `--prerelease` pour une version client.
- [ ] Entrée de `CHANGELOG.md`.
- [ ] Livrables et documentation archivés **10 ans**.

Correctif à reporter sur une version livrée :

```powershell
git switch release/2.4
git cherry-pick -x <sha>        # -x : trace du commit d'origine
# compiler avant de taguer : Git valide du texte, pas du code
git tag -a v2.4.1 -m "Correctif de sécurité CVE-…"
```

Le report passe lui aussi par pull request vers `release/2.4`, avec revue et build.

---

# Conventions

## Branches

GitHub Flow avec branches de release : `main` protégée et toujours livrable, branches de travail courtes (une par issue, supprimées après fusion), `release/x.y` par version livrée. Pas de `develop`.

Format `type/numéro-libellé-court`, en minuscules : `fix/142-timeout-modbus`, `feat/156-export-csv`.
Types : `feat`, `fix`, `hotfix`, `refactor`, `test`, `ci`, `chore`, `docs`.
Interdits : prénoms, `test`, `v2`, `final`, `ok`.

## Commits (Conventional Commits)

`type(portée): description`

| Type | Usage |
|---|---|
| `feat` | nouvelle fonctionnalité |
| `fix` | correction de défaut |
| `docs` | documentation seule |
| `refactor` | sans changement de comportement |
| `test` | tests |
| `build` | build, dépendances NuGet |
| `ci` | workflows |
| `chore` | divers sans effet produit |
| `perf` | performance |

- Rupture de compatibilité : `!` après le type, ou pied `BREAKING CHANGE:`.
- Un fichier qui ne change pas le logiciel livré (modèle, CODEOWNERS, workflow) : `docs`, `chore` ou `ci`, **jamais `fix`**.
- Correctif de sécurité : identifiant de vulnérabilité dans le corps.
- `Refs #N` dans le commit ; `Closes #N` dans la pull request.
- Commit de fusion : message proposé par GitHub (« Merge pull request #… »).

## Issues et pull requests

- Tout changement commence par une issue. Titre = le problème, pas la solution.
- La PR utilise le modèle, **rempli par son auteur**, référence l'issue (`Closes #`), porte un label de nature, met à jour le changelog si le comportement change.
- L'auteur n'approuve jamais sa propre PR, propriétaire compris.

## Revue

| Niveau | Bouton GitHub | Effet |
|---|---|---|
| `blocker` | Request changes | bloque la fusion |
| `suggestion` | Comment | à la main de l'auteur |
| `nit` | Comment | détail |
| `question` | Comment | attend une réponse |
| aucun `blocker` | Approve | |

Tout fil est résolu avant fusion. Une PR de plusieurs commits se relit aussi commit par commit. Jamais de fusion en force.

## Charte d'équipe

La charte vit dans `docs/charte-git.md` et se modifie par pull request. Points à trancher : rôles, durée de vie des branches, nombre d'approbations, délai de revue, contrôles requis, couverture visée, qui pose les tags, installateur, archivage, référent sécurité, **procédure d'urgence** (qui autorise un contournement, régularisation sous N jours), révision tous les six mois.

---

# Progression recommandée

Tout activer d'un coup produit un pipeline bloquant et l'abandon des règles en quinze jours.

| Phase | Contenu | Effet sur la fusion |
|---|---|---|
| 1, documentation | règles écrites (`SECURITY.md`, charte) | aucun |
| 2, visibilité | les contrôles s'exécutent sur `main` et signalent | aucun |
| 3, application | les contrôles échouent et bloquent | fusion bloquée |
| 4, délégation | la règle est dans l'outil | routine |

À bloquer en premier : **build et tests**, puis le **lien vers une issue**. Le blocage sur dépendance vulnérable vient quand l'équipe sait qualifier une alerte.

# Vérification finale du dépôt

- [ ] Chaque membre clone et pousse une branche
- [ ] Push direct sur `main` refusé, propriétaire compris
- [ ] PR sans approbation des code owners : non fusionnable
- [ ] PR avec build rouge : non fusionnable
- [ ] Modèles de PR et d'issue proposés automatiquement
- [ ] `dependabot.yml` sur `main`, alertes et mises à jour de sécurité actives
- [ ] Alertes de sécurité qualifiées, chacune avec une décision écrite
- [ ] Dernière version livrée : tag, release, binaire du pipeline, SBOM (DLL hors NuGet comprises)

## Points de vigilance à trois mois

- les branches longues reviennent ;
- la revue devient un tampon (approbations en moins de deux minutes) ;
- le contournement d'urgence devient l'usage ;
- les alertes s'accumulent sans tri ;
- **le nouveau dépôt nu** : créé sans cette procédure.
