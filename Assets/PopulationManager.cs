using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PopulationManager : MonoBehaviour {

	public GameObject botPrefab;
	public GameObject startingPos;
	public int populationSize = 50;
	List<GameObject> population = new List<GameObject>();
	public static float elapsed = 0;
	public float trialTime = 5;
	int generation = 1;
	public int deaths = 0;

	GUIStyle guiStyle = new GUIStyle();
	void OnGUI()
	{
		guiStyle.fontSize = 50;
		guiStyle.normal.textColor = Color.white;
		GUI.BeginGroup (new Rect (10, 10, 350, 300));
		GUI.Label(new Rect (5,10,200,50), "Gen: " + generation, guiStyle);
		GUI.Label(new Rect (5,90,200,50), string.Format("Time: {0:0.00}",elapsed), guiStyle);
		GUI.Label(new Rect(5, 170, 350, 50), "Population: " + population.Count, guiStyle);
		GUI.Label(new Rect(5, 250, 350, 50), "Alive: " + (population.Count - deaths), guiStyle);
		GUI.EndGroup ();
	}


	// Use this for initialization
	void Start () {
		for(int i = 0; i < populationSize; i++)
		{
			GameObject b = Instantiate(botPrefab, startingPos.transform.position, this.transform.rotation);
			b.GetComponent<Brain>().Init();
			population.Add(b);
		}
	}

	GameObject Breed(GameObject parent1, GameObject parent2)
	{
		GameObject offspring = Instantiate(botPrefab, startingPos.transform.position, this.transform.rotation);
		Brain b = offspring.GetComponent<Brain>();
		if(Random.Range(0,100) < 10) //mutate 20 in 100
		{
			b.Init();
			b.mutate();
			//double[,] perfectGene = { { -0.1 }, { -1.0 } };
			//b.gene = perfectGene;
			//b.gene = MathFunctions.Matrix.GenerateMatrix(4, 1, -1, 1);
			//b.gene[Random.Range(0, b.gene.GetLength(0)), Random.Range(0, b.gene.GetLength(1))] = (double)Random.Range(-1.0f,1.0f);
		}
		else
		{ 
			b.Init();
			for (int i = 0; i < b.gene.GetLength(0); i++)
			{
				for (int j = 0; i < b.gene.GetLength(1); i++)
				{
					b.gene[i,j] = Random.Range(0, 10) < 5 ? parent1.GetComponent<Brain>().gene[i,j] : parent2.GetComponent<Brain>().gene[i,j];
				}
			}
		}
		return offspring;
	}

	void BreedNewPopulation()
	{
		List<GameObject> sortedList = population.OrderBy(o => (o.GetComponent<Brain>().timeAlive)).ToList();
		
		population.Clear();
		for (int i = (int) (7*sortedList.Count / 8.0f) - 1; i < sortedList.Count - 1; i++)
		{
			population.Add(Breed(sortedList[i], sortedList[i + 1]));
			population.Add(Breed(sortedList[i + 1], sortedList[i]));
			population.Add(Breed(sortedList[i], sortedList[i + 1]));
			population.Add(Breed(sortedList[i + 1], sortedList[i]));
			population.Add(Breed(sortedList[i], sortedList[i + 1]));
			population.Add(Breed(sortedList[i + 1], sortedList[i]));
			population.Add(Breed(sortedList[i], sortedList[i + 1]));
			population.Add(Breed(sortedList[i + 1], sortedList[i]));
		}


		

		//destroy all parents and previous population
		for(int i = 0; i < sortedList.Count; i++)
		{
			Destroy(sortedList[i]);
		}
		generation++;
	}
	
	// Update is called once per frame
	void Update () {

		int deathCount = 0;
		for (int i = 0; i < populationSize; i++)
		{
			if (!(population[i].GetComponent<Brain>().alive))
			{
				deathCount++;
			}
			deaths = deathCount;
		}
		elapsed += Time.deltaTime;
		if( deathCount > populationSize-1)
		{
			BreedNewPopulation();
			elapsed = 0;

			spawn.pipe1.transform.position = Vector3.right * spawn.startPosition + Vector3.up * spawn.startHeight;
			spawn.pipe1.transform.position += Vector3.up * Random.Range(-spawn.height, spawn.height);

			spawn.pipe2.transform.position = Vector3.right * spawn.startPosition + Vector3.up * spawn.startHeight;
			spawn.pipe2.transform.position += Vector3.up * Random.Range(-spawn.height, spawn.height);
			spawn.pipe2.transform.position += Vector3.right * spawn.distance;
		}
	}
}
