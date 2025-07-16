namespace ConsoleApp.Classes;

// ✅ Classe estática responsável por ensinar: Produto de Matrizes e Sistemas Lineares
public static class MatrixProductAndLinearSystemClass
{
	public static void Run()
	{
		// ✅ Criação da matriz A 2x2
		// Representa, por exemplo, uma matriz de transformação linear
		double[,] A = {
			{ 2, 1 },
			{ 3, 4 }
		};
		Console.WriteLine("Matriz A:");
		PrintMatrix(A);

		// ✅ Criação da matriz B 2x2
		// Representa outra transformação a ser aplicada
		double[,] B = {
			{ 1, 2 },
			{ 0, 1 }
		};
		Console.WriteLine("\nMatriz B:");
		PrintMatrix(B);

		// ✅ Multiplica A por B: C = A · B
		// Isso simula uma composição de transformações
		Console.WriteLine("\nProduto A x B:");
		double[,] C = MultiplyMatrices(A, B);
		PrintMatrix(C);

		// ✅ Sistema Linear A · x = b
		// Vamos encontrar o vetor x que satisfaz essa equação
		Console.WriteLine("\nResolvendo sistema linear A * x = b");

		// Vetor b com resultados do sistema
		double[] b = { 5, 6 };

		// Soluciona o sistema usando a fórmula de Cramer (válida para 2x2)
		double[] x = Solve2x2LinearSystem(A, b);
		Console.WriteLine("Solução x:");
		PrintVector(x);
	}

	// ✅ Função que realiza a multiplicação entre duas matrizes
	public static double[,] MultiplyMatrices(double[,] A, double[,] B)
	{
		// Dimensões das matrizes
		int rowsA = A.GetLength(0); // Linhas de A
		int colsA = A.GetLength(1); // Colunas de A
		int rowsB = B.GetLength(0); // Linhas de B
		int colsB = B.GetLength(1); // Colunas de B

		// ❌ Verifica se a multiplicação é possível (colsA deve ser igual a rowsB)
		if (colsA != rowsB)
			throw new ArgumentException("Tamanhos incompatíveis para multiplicação de matrizes.");

		// ✅ Cria a matriz resultado com tamanho apropriado
		double[,] result = new double[rowsA, colsB];

		// ✅ Loop para multiplicar matrizes:
		// Cada célula [i,j] do resultado é a soma do produto escalar da linha i de A com a coluna j de B
		for (int i = 0; i < rowsA; i++)
			for (int j = 0; j < colsB; j++)
				for (int k = 0; k < colsA; k++)
					result[i, j] += A[i, k] * B[k, j];

		return result;
	}

	// ✅ Função para resolver um sistema linear 2x2: A · x = b
	// Retorna o vetor x contendo a solução
	public static double[] Solve2x2LinearSystem(double[,] A, double[] b)
	{
		// Extrai os coeficientes da matriz A
		double a = A[0, 0];
		double b1 = A[0, 1]; // b já é o nome do vetor, então usamos b1
		double c = A[1, 0];
		double d = A[1, 1];

		// ✅ Calcula o determinante de A
		// Fórmula: det(A) = a*d - b*c
		double det = a * d - b1 * c;

		// ❌ Verifica se a matriz é invertível (det ≠ 0)
		if (Math.Abs(det) < 1e-10)
			throw new InvalidOperationException("Sistema sem solução única.");

		// ✅ Calcula a solução usando a Regra de Cramer para 2x2
		double[] x = new double[2];
		x[0] = (b[0] * d - b1 * b[1]) / det;
		x[1] = (a * b[1] - b[0] * c) / det;

		return x;
	}

	// ✅ Função auxiliar para imprimir matrizes no console
	public static void PrintMatrix(double[,] m)
	{
		int rows = m.GetLength(0); // Número de linhas
		int cols = m.GetLength(1); // Número de colunas

		for (int i = 0; i < rows; i++)
		{
			Console.Write("[ ");
			for (int j = 0; j < cols; j++)
				Console.Write($"{m[i, j]} "); // Imprime o valor da célula
			Console.WriteLine("]");
		}
	}

	// ✅ Função auxiliar para imprimir vetores no console
	public static void PrintVector(double[] v) =>
		Console.WriteLine("[ " + string.Join(", ", v.Select(n => n.ToString("F2"))) + " ]");
}