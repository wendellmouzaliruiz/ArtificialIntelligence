namespace ConsoleApp.Classes;

// ✅ Classe estática responsável por ensinar: Vetores e Matrizes
public static class VectorsAndMatricesClass
{
	public static void Run()
	{
		// ✅ Cria um vetor linha (ou seja, um array com 1 dimensão)
		// Isso representa um vetor no espaço — ex: (1, 2, 3)
		double[] vector = { 1, 2, 3 };
		Console.WriteLine("Vetor:");
		PrintVector(vector);

		// ✅ Cria uma matriz 2x3: 2 linhas e 3 colunas
		// Essa matriz poderia representar pesos de uma rede neural, por exemplo
		double[,] matrix = {
			{ 1, 2, 3 },   // Linha 0
			{ 4, 5, 6 }    // Linha 1
		};
		Console.WriteLine("\nMatriz:");
		PrintMatrix(matrix);

		// ✅ Transpõe a matriz para poder multiplicar com o vetor
		// A multiplicação de um vetor linha (1x3) com uma matriz (2x3) exige que
		// a matriz seja transposta para virar (3x2), ou seja, compatível
		double[,] transposed = Transpose(matrix);

		// ✅ Multiplica o vetor (1x3) pela matriz transposta (3x2)
		// Resultado: um novo vetor (1x2)
		double[] result = MultiplyVectorByMatrix(vector, transposed);
		Console.WriteLine("\nResultado da multiplicação Vetor x Matriz:");
		PrintVector(result);
	}

	// ✅ Função para imprimir vetores
	public static void PrintVector(double[] v) =>
		Console.WriteLine("[ " + string.Join(", ", v.Select(n => n.ToString("F2"))) + " ]");

	// ✅ Função para imprimir matrizes
	public static void PrintMatrix(double[,] m)
	{
		int rows = m.GetLength(0); // Número de linhas
		int cols = m.GetLength(1); // Número de colunas

		for (int i = 0; i < rows; i++)
		{
			Console.Write("[ ");
			for (int j = 0; j < cols; j++)
				Console.Write($"{m[i, j]} "); // Imprime cada elemento da linha
			Console.WriteLine("]");
		}
	}

	// ✅ Transpõe uma matriz: troca linhas por colunas
	public static double[,] Transpose(double[,] matrix)
	{
		int rows = matrix.GetLength(0);
		int cols = matrix.GetLength(1);
		double[,] transposed = new double[cols, rows]; // Inverte dimensões

		for (int i = 0; i < rows; i++)
			for (int j = 0; j < cols; j++)
				transposed[j, i] = matrix[i, j]; // Coluna vira linha

		return transposed;
	}

	// ✅ Multiplica um vetor por uma matriz
	// Exige que o número de elementos do vetor == número de linhas da matriz
	public static double[] MultiplyVectorByMatrix(double[] vector, double[,] matrix)
	{
		int rows = matrix.GetLength(0); // linhas da matriz = tamanho do vetor
		int cols = matrix.GetLength(1); // colunas da matriz = tamanho do resultado

		if (vector.Length != rows)
			throw new ArgumentException("Tamanhos incompatíveis para multiplicação.");

		double[] result = new double[cols]; // Vetor resultante

		// Para cada coluna da matriz, faz o produto escalar com o vetor
		for (int j = 0; j < cols; j++)
			for (int i = 0; i < rows; i++)
				result[j] += vector[i] * matrix[i, j];

		return result;
	}
}
