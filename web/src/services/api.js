const apiBaseUrl = import.meta.env.VITE_API_BASE_URL;

export async function getMonthlySummary(query) {
  try {
    const response = await fetch(`${apiBaseUrl}/Monthly/query`, {
      method: 'POST',
      headers: {
        'Content-Type': 'application/json',
      },
      body: JSON.stringify(query),
    });

    if (!response.ok) {
      throw new Error('網路錯誤: ' + response.statusText);
    }

    return await response.json();
  } catch (error) {
    console.error('操作錯誤:', error);
    throw error;
  }
}

export async function addMonthlyRevenue(data) {
  try {
    const response = await fetch(`${apiBaseUrl}/Monthly/add`, {
      method: 'POST',
      headers: {
        'Content-Type': 'application/json',
      },
      body: JSON.stringify(data),
    });

    if (!response.ok) {
      throw new Error('網路錯誤: ' + response.statusText);
    }

    return await response.json();
  } catch (error) {
    console.error('操作錯誤:', error);
    throw error;
  }
}
