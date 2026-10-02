# CHANGELOG WinVOIE

## Non publié

### Sécurité
- Les mots de passe des accès maintenance (paramètres machine, réglage des zéros, configuration mail)
  ne sont plus écrits dans le programme. Ils sont lus, sous forme d'empreinte, dans
  `C:\WVOIE\PARAMETRES\acces.par`, créé à l'installation par le SAV (`outils\creer-acces.ps1`).
- **Action à l'installation** : sans ce fichier, aucun accès maintenance n'est possible.
- Les anciens mots de passe sont abandonnés ; les nouveaux distinguent majuscules et minuscules.

## 6.73h
- Export PDF des enregistrements travail (PDFsharp 6.2.4)
- Envoi des enregistrements par mail depuis l'écran impression
- Signature des fichiers enregistrement (contrôle modification)

## 6.72
- Passage .NET Framework 4.8
- Mise à jour Newtonsoft.Json 13.0.4
- Filtre DAO calculé au démarrage (MathNet.Numerics)

## 6.70
- Liaison TCP PC enregistrement (remplace RS232)
- Export contexte SAV (zip sur le bureau)
