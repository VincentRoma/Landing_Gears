# Landing_Gears

## Développement 

### Cycle de vie

Pour la realisation de ce projet, j’ai développé en suivant la méthodologie SCRUM. Cette approche m’a permis de développer tout en ayant une boucle de feedback au fur et à mesure de mes avancées.
C’est une méthode simple et efficace de management de projet qui permet de tester rapidement du afin de valider la progression. Les taches sont découpées selon des sprints, qui durent environ une semaine. Lors d’un développement en SCRUM, il est recommandé d’utilisé un SCRUM board afin d’organiser les taches relatives à chaque sprint, pour ce faire j’ai utilisé Waffle (waffle.io), ce qui m’a permis de classer mes issues Github sous forme de tableau SCRUM.


### Utilisation de GIT 

Bien que je sois seul dans mon équipe, l’utilisation de git était nécessaire pour des soucis de qualité. Il a fallu décrire toutes les taches ainsi que leurs priorités et la release à laquelle elles appartiennent. Pour ce faire, Github offre la possibilité de crée des “Milestones” qui correspondent à des releases, ma première Milestone correspond au premier rendu et comporte tout les éléments requis, ainsi que quelque “enhancements”.
Lors d’un développement collaboratif utilisant GIT, il est conseillé d’avoir au minimum une branche master et dev. Pour chaque nouvelle feature il faut alors créer une nouvelle branche depuis dev, implémenter la feature sur cette branche et proposer ensuite une pull-request vers dev.
A chaque release, la branche dev est merge dans master, ce qui idéalement, déclenche le script de déploiement à la suite des tests.

### Documentation

L’architecture utilisée pour le développement de ce projet est la suivante:
Le ControlPanel est la classe mère qui contient les 3 objects GearSet correspondants aux trois paires de Door/Gear. L’affichage lumineux est représenté par la classe LightControl, contenue également dans le ControlPanel. Chaque Gear, Door et GearSet a une variable state qui a pour fonction de remonter les erreurs entre les différents modules.


## Tests

### Validation : Scénarios

Pour assurer le bon fonctionnement de notre application, il est primordiale d’implémenter des tests fonctionnels ainsi qu’unitaire. Les tests unitaires permettent de vérifier le bon fonctionnement de chaque fonction, de manière isolée. Il suffit de créer différents scénarios (différentes variables à passer à la méthode) et d’observer les valeurs de retour afin de vérifier que le comportement est celui auquel on s’attend.
Par la suite, les tests fonctionnels permettent d’assurer le bon fonctionnement global de l’application et plus précisément que l’utilisateur peut réaliser toutes les actions prévus par le logiciel.

Les tests fonctionnels à réaliser:

	- A l’état initial, les trains sont rentrés.
	- L’utilisateur appuie sur DOWN est l’extraction débute.
	- L’utilisateur appuie sur UP durant l’extraction est celle-ci s’annule.
	- Si l’utilisateur n’appuie pas sur UP, l’extraction se termine et indique un voyant vert.
	- L’utilisateur appuie sur DOWN alors que l’extraction est complète.
	- L’utilisateur appuie sur UP, la rétractation débute.
	- L’utilisateur appuie sur DOWN durant la rétractation, celle-ci s’annule.
	- La rétractation se termine correctement, les voyants s’éteignent.
	- La rétraction ou l’extraction génère une erreur, le voyant passe au rouge.


### Description du fonctionnement 

Lorsque l’application démarre, l’utilisateur se trouve dans l’état initial: les trains sont rentrés, les portes sont fermées et les voyants sont éteints. En appuyant sur DOWN le déploiement se déclenche, le ControlPanel crée trois instances de GearSet et lance leurs méthodes de fonctionnement dans un Tread. Le GearSet contient une Door ainsi qu’un Gear, il lance alors l’ouverture de la porte et s’assure que celle-ci soit ouverte avant de déployer le Gear. Une fois le Gear en position finale, il signal au ControlPanel le bon ou mauvais déroulement du déploiement. Le ControlPanel attend alors les retours de tout les threads avant de changer l’états de l’affichage lumineux en conséquence.
