# Plan d'action CRA : WinVOIE

Établi le 03/10/2026 par LaPolaris et ladel1 (dépôt de démonstration, entreprise fictive FERRODEMO)
Échéance générale de conformité : 11/12/2027. Signalement de l'article 14 applicable depuis le 11/09/2026.

## Étape 1 : cartographie des produits

| Produit | Description | Pile technique | Fin de support du runtime | Clients installés | Versions en service | Classification probable | À vérifier contre |
|---|---|---|---|---|---|---|---|
| WinVOIE | supervision et réglage d'une machine de travaux de voie, liaison automate Beckhoff | VB.NET, Windows Forms, .NET Framework 4.8, `packages.config` | celle de la version de Windows qui embarque .NET Framework 4.8 | **inconnu** | **inconnu** (seule `v6.73.1` est tracée) | catégorie par défaut probable ; logiciel pilotant un équipement industriel : vérification à tracer | annexes III et IV du texte officiel |

Première action du plan : connaître les versions en service par client. Sans elle, un signalement de 24 heures est intenable.

## Étape 2 : évaluation des écarts (annexe I partie II)

| Exigence | État au 03/10/2026 (preuve dans le dépôt) | Écart | Action | Responsable | Échéance |
|---|---|---|---|---|---|
| 1. Inventaire des composants, SBOM | SBOM CycloneDX `WinVOIE-6.73.1.cdx.json` attaché à la release, produit par le pipeline depuis le tag ; 15 composants dont TwinCAT.Ads et Fde.Vmp60.Network (empreinte SHA-256) | aucune version antérieure n'a de SBOM ; licence « Unknown » sur 6 paquets System.* | retrouver les versions en service et produire leur SBOM ; compléter les licences | LaPolaris | 31/12/2026 |
| 2. Remédiation sans délai | alertes Dependabot, malware et mises à jour de sécurité actives ; revue des dépendances bloquante (PR #21) ; sonde de liaisons dans `build` (PR #35) ; décisions écrites (issue #25) | aucun délai de correction défini ; aucune branche de release surveillée ; migration Microsoft.Extensions 8.x → 10.x non planifiée | fixer les délais par gravité ; créer l'issue de migration avec PDFsharp | ladel1 | 31/10/2026 |
| 3. Tests et revues de sécurité réguliers | 6 contrôles requis ; 9 tests ; revue CODEOWNERS ; analyseurs Roslyn et DevSkim sur `main` ; Gitleaks sur tout l'historique | alertes Code scanning restantes non triées (DevSkim « DES », CA1031, CA2000…) ; couverture de tests non mesurée ; CodeQL inapplicable (VB) | trier les alertes avec décision écrite ; mesurer la couverture du périmètre métier | ladel1 | 30/11/2026 |
| 4. Publication des correctifs | release `v6.73.1`, CHANGELOG section « Sécurité » (mots de passe en dur, DTD) | aucun avis de sécurité publié ; clients non informés | publier un avis GitHub (Security Advisory) par correctif de sécurité | LaPolaris | 31/10/2026 |
| 5. Politique de divulgation coordonnée | `SECURITY.md` (délais, 90 jours, article 14) | délais et adresse d'exemple, non validés par la direction | faire valider délais et adresse | direction | 31/10/2026 |
| 6. Point de contact et facilitation du signalement | `SECURITY.md` ; signalement privé GitHub activé (dépôt public) | adresse fictive ; pas de `security.txt` | adresse réelle et surveillée ; publier `/.well-known/security.txt` | LaPolaris | 31/10/2026 |
| 7. Distribution sécurisée des mises à jour | attestation de provenance sur l'exécutable et le livrable, liée au commit du tag | binaire non signé ; installateur fait à la main (`Setup.vdproj`) | choisir le certificat (OV, EV, cloud) ; produire l'installateur dans le pipeline (WiX) | direction, puis LaPolaris | 30/06/2027 |
| 8. Correctifs sans délai et gratuits | `SECURITY.md` annonce la gratuité pour les versions prises en charge | décision non validée par la direction | remonter la décision | direction | 31/10/2026 |

### Annexe I partie I : les trois écarts principaux

| Point | État | Écart |
|---|---|---|
| Journalisation des événements de sécurité | journal local (`LogMod`) : accès aux paramètres et sauvegardes de réglages | échecs de mot de passe non journalisés ; journal modifiable sur le poste |
| Gestion des accès | mots de passe sortis du code, empreintes PBKDF2 par profil (PR #18) | pas d'identité nominative ; l'export « contexte SAV » archive tout `C:\WVOIE`, mot de passe SMTP en clair compris |
| Mécanisme de mise à jour | release GitHub, installateur manuel | pas de mise à jour signée ni vérifiée à l'installation |

## Étape 3 : feuille de route

**Immédiat, avant le 31/10/2026**
- inventaire des versions installées par client : LaPolaris, 17/10/2026
- référent vulnérabilités et suppléant désignés (étape 4) : direction, 10/10/2026
- compte sur la plateforme de signalement de l'ENISA ouvert : ladel1, 17/10/2026
- `SECURITY.md` validé et `security.txt` publié, adresse réelle : LaPolaris, 31/10/2026
- procédure d'escalade hors heures ouvrées écrite : ladel1, 31/10/2026

**Trimestre 4 2026 et trimestre 1 2027**
- alertes Code scanning restantes triées, décision écrite pour chacune : ladel1, 30/11/2026
- migration Microsoft.Extensions / Pkcs 8.x → 10.x avec PDFsharp : ladel1, 31/01/2027
- export « contexte SAV » excluant les fichiers de mots de passe : LaPolaris, 31/12/2026
- migration `packages.config` → `PackageReference` : ladel1, 31/03/2027
- décision sur l'offre GitHub si le dépôt réel est privé (Code Security, Secret Protection, Enterprise Cloud pour la provenance) : direction, 31/12/2026

**Trimestre 2 et trimestre 3 2027**
- certificat de signature choisi, signature intégrée au workflow `release` : LaPolaris, 30/06/2027
- installateur produit par le pipeline (WiX) : ladel1, 30/06/2027
- journalisation des événements de sécurité (échecs d'accès compris) : ladel1, 30/09/2027
- période de support définie et annoncée aux clients : direction, 30/06/2027
- archivage à dix ans hors GitHub en place : LaPolaris, 30/09/2027

**Trimestre 4 2027, avant le 11/12/2027**
- documentation technique conforme à l'annexe VII : LaPolaris, 15/11/2027
- évaluation de la conformité selon la classification retenue : direction, 30/11/2027
- déclaration UE de conformité et marquage CE : direction, 10/12/2027
- revue complète : LaPolaris et ladel1, 10/12/2027

## Étape 4 : rôles internes

| Rôle | Personne | Suppléant | Responsabilités |
|---|---|---|---|
| Référent sécurité | LaPolaris | ladel1 | veille, alertes Dependabot, arbitrage technique |
| Référent vulnérabilités | ladel1 | LaPolaris | qualification d'un signalement, déclenchement de la procédure article 14, accès au compte ENISA |
| Référent documentation | LaPolaris | ladel1 | documentation technique, archivage, conservation |

Noter par écrit l'heure du premier signal **et** l'heure de prise de connaissance : c'est la seconde qui fait courir le délai.

## Limites du plan

Trois sujets relèvent de la direction et sont remontés, pas tranchés ici :
- la qualification juridique définitive du produit et du rôle de l'entreprise
- la gratuité des correctifs de sécurité, y compris hors contrat de maintenance
- la durée de support annoncée
