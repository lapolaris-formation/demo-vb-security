# Ajoute au SBOM CycloneDX les DLL de fournisseurs versionnées dans WinBAO/dll :
# CycloneDX ne connaît que les paquets NuGet, ces composants n'y figurent pas (jours 4 et 5).
# Usage : python3 sbom-hors-nuget.py <bom.json> <dossier des DLL>
import hashlib
import json
import os
import sys

# À COMPLÉTER par l'équipe : une ligne par DLL de fournisseur livrée sans NuGet (votre projet WBAO).
# Exemple, dans le jumeau :
#   {"fichier": "TwinCAT.Ads.dll", "nom": "TwinCAT.Ads", "version": "4.3.30",
#    "editeur": "Beckhoff Automation", "licence": "Propriétaire Beckhoff"},
# Liste vide : le script ne fait rien, et le SBOM ne contient que les paquets NuGet.
COMPOSANTS = [
]

bom_chemin, dossier = sys.argv[1], sys.argv[2]
with open(bom_chemin, encoding="utf-8") as f:
    bom = json.load(f)

for c in COMPOSANTS:
    with open(os.path.join(dossier, c["fichier"]), "rb") as f:
        empreinte = hashlib.sha256(f.read()).hexdigest()
    bom.setdefault("components", []).append({
        "type": "library",
        "bom-ref": c["nom"] + "@" + c["version"],
        "name": c["nom"],
        "version": c["version"],
        "publisher": c["editeur"],
        "description": "DLL hors NuGet, versionnée dans WinBAO/dll",
        "licenses": [{"license": {"name": c["licence"]}}],
        "hashes": [{"alg": "SHA-256", "content": empreinte}],
    })
    print("ajouté :", c["nom"], c["version"], empreinte)

with open(bom_chemin, "w", encoding="utf-8") as f:
    json.dump(bom, f, ensure_ascii=False, indent=2)
